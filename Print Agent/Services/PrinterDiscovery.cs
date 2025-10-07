using Zeroconf;
using System.Net;

namespace Print_Agent.Services;

public sealed class DiscoveredPrinter
{
	public string Name { get; init; } = "";
	public string Hostname { get; init; } = "";
	public string Address { get; init; } = "";
	public int? Port { get; init; }
	public string? ServiceType { get; init; }
	public Dictionary<string, string>? Txt { get; init; }
}

public static class PrinterDiscovery
{
	private static readonly string[] Types =
	{
		"_ipp._tcp.local.",
		"_ipps._tcp.local.",
		"_printer._tcp.local."
	};

	public static async Task<IReadOnlyList<DiscoveredPrinter>> DiscoverAsync(TimeSpan? timeout = null)
	{
		timeout ??= TimeSpan.FromSeconds(4);

		var found = new List<DiscoveredPrinter>();

		foreach (var type in Types)
		{
			var scan = timeout ?? TimeSpan.FromSeconds(4);   // ensure non-null
			var hosts = await ZeroconfResolver.ResolveAsync(type, scan, 2, 1500);

			foreach (var h in hosts)
			{
				// IPv4 first if possible
				var ip = h.IPAddresses?.FirstOrDefault(a =>
							 IPAddress.TryParse(a, out var ipObj) &&
							 ipObj.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
						 ?? h.IPAddress
						 ?? "";

				foreach (var svc in h.Services.Values)
				{
					var txt = ZeroconfTxt.Flatten(svc);

					var name = (txt != null && txt.TryGetValue("ty", out var ty) && !string.IsNullOrWhiteSpace(ty))
						? ty
						: (!string.IsNullOrWhiteSpace(h.DisplayName) ? h.DisplayName! : ip);

					found.Add(new DiscoveredPrinter
					{
						Name = name,
						Hostname = h.DisplayName ?? ip,
						Address = ip,
						Port = svc.Port,
						ServiceType = svc.Name,
						Txt = txt
					});
				}
			}
		}

		// De-dup by address:port:type
		return found
			.GroupBy(p => $"{p.Address}:{p.Port}:{p.ServiceType}")
			.Select(g => g.First())
			.ToList();
	}
}

static class ZeroconfTxt
{
	public static Dictionary<string, string>? Flatten(IService svc)
	{
		var p = svc.Properties;
		if (p is null) return null;

		// Handles multiple Zeroconf shapes
		if (p is IDictionary<string, string> dict)
			return new Dictionary<string, string>(dict);

		if (p is IReadOnlyDictionary<string, string> ro)
			return ro.ToDictionary(kv => kv.Key, kv => kv.Value);

		if (p is IReadOnlyList<IReadOnlyDictionary<string, string>> list)
		{
			var merged = new Dictionary<string, string>();
			foreach (var d in list)
				foreach (var kv in d)
					if (!merged.ContainsKey(kv.Key)) // keep first value per key
						merged[kv.Key] = kv.Value;
			return merged;
		}

		if (p is IEnumerable<KeyValuePair<string, string>> seq)
			return seq.GroupBy(kv => kv.Key).ToDictionary(g => g.Key, g => g.First().Value);

		return null;
	}
}
