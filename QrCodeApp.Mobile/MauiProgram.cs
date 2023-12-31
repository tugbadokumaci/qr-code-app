using Microsoft.Extensions.Logging;
using QrCodeApp.Mobile.Services;
using QrCodeApp.Mobile.ViewModels;
using QrCodeApp.Mobile.Views;
using CommunityToolkit.Maui;

namespace QrCodeApp.Mobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiCommunityToolkit(options =>
        {
            options.SetShouldSuppressExceptionsInConverters(true);
        });
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemiold");
        }).UseMauiCommunityToolkit();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<SignupView>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<DetailCardView>();
        builder.Services.AddTransient<AddCardView>();
        builder.Services.AddTransient<ShowQRCodeView>();
        builder.Services.AddTransient<ScanView>();


        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<DetailCardViewModel>();
        builder.Services.AddTransient<AddCardViewModel>();
        builder.Services.AddTransient<ShowQRCodeViewModel>();
        builder.Services.AddTransient<ScanViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}