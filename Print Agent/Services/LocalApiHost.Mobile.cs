#if !WINDOWS
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Microsoft.AspNetCore.Components;

namespace Print_Agent.Services;

public sealed class LocalApiHostMobile : WebApiController, ILocalApiHost
{
	private WebServer? _server;

	[EmbedIO.Routing.Route(HttpVerbs.Get, "/")]
	public object Root() => new { status = "ok" };

	[EmbedIO.Routing.Route(HttpVerbs.Get, "/printers")]
	public async Task<object> GetPrinters()
		=> await PrinterDiscovery.DiscoverAsync(TimeSpan.FromSeconds(5));

	public async Task StartAsync(int port, CancellationToken ct = default)
	{
		var url = $"http://*:{port}/";
		_server = new WebServer(o => o.WithUrlPrefix(url).WithMode(HttpListenerMode.EmbedIO))
			.WithWebApi("/", m => m.WithController(() => this));

		_ = _server.RunAsync(ct);
		await Task.CompletedTask;
	}

	public ValueTask DisposeAsync()
	{
		_server?.Dispose();
		_server = null;
		return ValueTask.CompletedTask;
	}
}
#endif
