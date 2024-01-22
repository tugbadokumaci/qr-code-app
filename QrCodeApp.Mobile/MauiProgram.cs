using Microsoft.Extensions.Logging;
using QrCodeApp.Mobile.ViewModels;
using QrCodeApp.Mobile.Views;
using CommunityToolkit.Maui;
using Camera.MAUI;

namespace QrCodeApp.Mobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers =>
            {
#if IOS
                    handlers.AddHandler(typeof(Shell), typeof(QrCodeApp.Mobile.Platforms.iOS.CustomShellRenderer));
#endif
#if ANDROID
                handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomShellHandler));
#endif
            });

        builder.UseMauiCommunityToolkit(options =>
        {
            options.SetShouldSuppressExceptionsInConverters(true);
        });


        builder.UseMauiApp<App>()
            .UseMauiCameraView()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemiold");
            fonts.AddFont("Inter-Black.ttf", "InterBlack");
            fonts.AddFont("Inter-Bold.ttf", "InterBold");
            fonts.AddFont("Inter-ExtraBold.ttf", "InterExtraBold");
            fonts.AddFont("Inter-ExtraLight.ttf", "InterExtraLight");
            fonts.AddFont("Inter-Light.ttf", "InterLight");
            fonts.AddFont("Inter-Medium.ttf", "InterRegular");
            fonts.AddFont("Inter-Regular.ttf", "InterRegular");
            fonts.AddFont("Inter-Semibold.ttf", "InterSemibold");
            fonts.AddFont("Inter-Thin.ttf", "InterThin");

        }).UseMauiCommunityToolkit();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<SignupView>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<DetailCardView>();
        builder.Services.AddTransient<AddCardView>();
        builder.Services.AddTransient<ShowQRCodeView>();
        builder.Services.AddTransient<ScanView>();
        builder.Services.AddTransient<SavedView>();
        builder.Services.AddTransient<ReadyToScanView>();
        builder.Services.AddTransient<ManualScanView>();


        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<DetailCardViewModel>();
        builder.Services.AddTransient<AddCardViewModel>();
        builder.Services.AddTransient<ShowQRCodeViewModel>();
        builder.Services.AddTransient<ScanViewModel>();
        builder.Services.AddTransient<SavedViewModel>();
        builder.Services.AddTransient<ManualScanViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}