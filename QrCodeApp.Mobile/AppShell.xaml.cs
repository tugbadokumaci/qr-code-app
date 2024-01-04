using QrCodeApp.Mobile.Views;

namespace QrCodeApp.Mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
        Routing.RegisterRoute(nameof(DetailCardView), typeof(DetailCardView));
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        Routing.RegisterRoute(nameof(SignupView), typeof(SignupView));
        Routing.RegisterRoute(nameof(ShowQRCodeView), typeof(ShowQRCodeView));
        Routing.RegisterRoute(nameof(AddCardView), typeof(AddCardView));
        Routing.RegisterRoute(nameof(ScanView), typeof(ScanView));

    }
}

