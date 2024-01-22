using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class ReadyToScanView : ContentView
{
	public ReadyToScanView()
	{
		InitializeComponent();
	}
    private async void GoButton_Clicked(object sender, EventArgs e)
    {

        await Application.Current.MainPage.Navigation.PushAsync(new ScanView(new ScanViewModel()));

    }
}
