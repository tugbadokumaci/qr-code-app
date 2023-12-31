using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class SavedView : ContentPage
{
    private readonly SavedViewModel _viewModel;

    public SavedView(SavedViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;
	}
}
