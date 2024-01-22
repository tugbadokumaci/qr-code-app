using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class ManualScanView : ContentPage
{
    private readonly ManualScanViewModel _viewModel;

    public ManualScanView(ManualScanViewModel vm)
    {
        _viewModel = vm;
        BindingContext = _viewModel;
        InitializeComponent();
    }
}
