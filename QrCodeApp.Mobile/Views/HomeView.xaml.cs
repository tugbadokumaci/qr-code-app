using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class HomeView : ContentPage
{

    private readonly HomeViewModel _viewModel;

    public HomeView(HomeViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		BindingContext = _viewModel;

	}
}
