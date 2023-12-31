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
}
