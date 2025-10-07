using Microsoft.Extensions.Logging;
using Print_Agent.Services;

namespace Print_Agent
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			// Register the right local API host per platform
#if WINDOWS
            builder.Services.AddSingleton<ILocalApiHost, LocalApiHostWindows>();
#else
			builder.Services.AddSingleton<ILocalApiHost, LocalApiHostMobile>();
#endif

			var app = builder.Build();

			// Start the local HTTP endpoint (e.g., http://<device-ip>:5278)
			var api = app.Services.GetRequiredService<ILocalApiHost>();
			_ = api.StartAsync(5278);

			return app;
		}
	}
}
