using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class ScanView : ContentPage
{
    private readonly ScanViewModel _viewModel;

    public ScanView(ScanViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;
	}

    void cameraView_CamerasLoaded(System.Object sender, System.EventArgs e)
    {
    }

    void cameraView_BarcodeDetected(System.Object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        //MainThread.BeginInvokeOnMainThread(() =>
        //{
        //    result.Text = $" {args.Result[0].BarcodeFormat} : {args.Result[0].Text}";
        //}

        //);
    }

    async void ImageButton_ClickedAsync(object sender, EventArgs e)
    {
        try
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ManualScanView(new ManualScanViewModel()));
        }
        catch (Exception ex)
        {
            // Handle navigation errors here
        }
    }
}
