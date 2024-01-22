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

    //private async void ImageButton_Clicked(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        // Attempt to navigate back using the built-in mechanism
    //        await Shell.Current.Navigation.PopAsync(); // Go back
    //    }
    //    catch (InvalidOperationException)
    //    {
    //        // If navigation fails (e.g., no previous page), handle gracefully
    //        await DisplayAlert("No Previous Page", "There is no previous page to go back to.", "OK");
    //    }
    //}
}
