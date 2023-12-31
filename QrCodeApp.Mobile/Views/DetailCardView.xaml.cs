using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class DetailCardView : ContentPage
{
    private readonly DetailCardViewModel _viewModel;

    public DetailCardView(DetailCardViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }
}
