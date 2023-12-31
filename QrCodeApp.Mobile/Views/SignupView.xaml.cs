using QrCodeApp.Mobile.ViewModels;

namespace QrCodeApp.Mobile.Views;

public partial class SignupView : ContentPage
{
	public SignupView(SignupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
