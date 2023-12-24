using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class CardPage : ContentPage
{
	public CardPage(CardViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;

    }
}
