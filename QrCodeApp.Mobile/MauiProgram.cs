using Microsoft.Extensions.Logging;
using QrCodeApp.Mobile.Services;
using QrCodeApp.Mobile.ViewModels;
using QrCodeApp.Mobile.Views;

namespace QrCodeApp.Mobile;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//builder.Services.AddHttpClient("api", httpClient=>httpClient.BaseAddress = new Uri("https://localhost:7204/WeatherForecast"));
		//builder.Services.AddTransient<CardPage>();
		//builder.Services.AddTransient<CardViewModel>();
		//builder.Services.AddTransient<CardService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

