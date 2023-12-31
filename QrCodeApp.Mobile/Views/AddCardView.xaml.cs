using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class AddCardView : ContentPage
{
    private readonly AddCardViewModel _viewModel;

    public AddCardView(AddCardViewModel vm)
	{
		InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;

    }
}
