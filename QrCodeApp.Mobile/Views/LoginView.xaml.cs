namespace QrCodeApp.Mobile.Views;

using Microsoft.Maui.Controls;
using QrCodeApp.Mobile.ViewModels;

public partial class LoginView : ContentPage
{
    private readonly LoginViewModel _viewModel;

    public LoginView(LoginViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

}
