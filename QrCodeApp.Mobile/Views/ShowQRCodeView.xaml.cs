using QrCodeApp.Mobile.ViewModels;
using Microsoft.Maui.Controls;

namespace QrCodeApp.Mobile.Views
{
    public partial class ShowQRCodeView : ContentPage
    {
        private readonly ShowQRCodeViewModel _viewModel;

        public ShowQRCodeView(ShowQRCodeViewModel vm)
        {
            InitializeComponent();
            _viewModel = vm;
            BindingContext = _viewModel;
        }
    }
}
