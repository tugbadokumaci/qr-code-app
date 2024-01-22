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

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Navigate to the HomePage route
            await Shell.Current.GoToAsync(nameof(AddCardView));
        }
        catch (InvalidOperationException)
        {
            // Handle navigation failure gracefully
            await DisplayAlert("Error", "Failed to navigate to HomePage.", "OK");
        }
    }


}
