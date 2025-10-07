#if WINDOWS
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Print_Agent.Services;
using Microsoft.AspNetCore.Http;

namespace Print_Agent.Services;

public sealed class LocalApiHostWindows : ILocalApiHost
{
    private WebApplication? _app;

    public async Task StartAsync(int port, CancellationToken ct = default)
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();

        app.MapGet("/", () => Results.Ok(new { status = "ok" }));
        app.MapGet("/printers", async () =>
        {
            var printers = await PrinterDiscovery.DiscoverAsync(TimeSpan.FromSeconds(5));
            return Results.Json(printers);
        });

        app.Urls.Add($"http://0.0.0.0:{port}");
        _ = app.RunAsync();
        _app = app;
        await Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        if (_app is IAsyncDisposable ad) await ad.DisposeAsync();
    }
}
#endif
