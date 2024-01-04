
using Newtonsoft.Json;
using QrCodeApp.Mobile;
using QrCodeApp.Mobile.ViewModels;
using QrCodeApp.Mobile.Views;

namespace QrCodeApp.Mobile;

public partial class App : Application
{
    public static string BaseUrl { get; private set; }
    public App()
    {
        BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5042/api" : "http://localhost:5042/api";

        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new NavigationPage(new HomeView(new HomeViewModel()));
        //MainPage = new NavigationPage(new LoginView(new LoginViewModel()));
        //MainPage = new NavigationPage(new DetailCardView(new DetailCardViewModel()));
        //MainPage = new NavigationPage(new ShowQRCodeView(new ShowQRCodeViewModel()));
        //MainPage = new AppShell();
    }
}

