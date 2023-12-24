using QrCodeApp.Mobile.ViewModels;
using QrCodeApp.Mobile.Views;

namespace QrCodeApp.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new AppShell();
        MainPage = new CardPage(new CardViewModel(new Services.CardService()));

    }
}

