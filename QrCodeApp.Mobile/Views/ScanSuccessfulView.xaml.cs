using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class ScanSuccessfulView : ContentView
{
	public ScanSuccessfulView()
	{
		InitializeComponent();
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        //await Application.Current.MainPage.Navigation.PushAsync(new ReadyToScanView());
    }

    async void ImageButton_ClickedAsync(System.Object sender, System.EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ScanView(new ScanViewModel()));


    }
}
