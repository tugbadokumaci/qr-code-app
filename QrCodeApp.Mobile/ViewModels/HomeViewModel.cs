using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using QrCodeApp.Mobile.Views;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Mobile.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private bool isRefreshing;
    public bool IsRefreshing
    {
        get => isRefreshing;
        set => SetProperty(ref isRefreshing, value);
    }


    public Command RefreshCommand { get; set; }


    private System.Collections.IEnumerable cards;

    public System.Collections.IEnumerable Cards
    {
        get => cards;
        set => SetProperty(ref cards, value);
    }



    public HomeViewModel()
    {
        SelectCommand = new Command(async () => await Selected());
        RefreshCommand = new Command(() => OnRefresh());
        GetHomePageDetails();
    }

    private void OnRefresh()
    {
        // Your logic to refresh the data
        GetHomePageDetails();
    }

    public ICommand SelectCommand { get; set; }


    private async Task Selected()
    {
        if (SelectedItem == null)
            return;
        var item = SelectedItem;
        SelectedItem = null;
        await Shell.Current.GoToAsync($"blogDetail?id={item.Id}");
    }

    public CardModel SelectedItem { get; set; }


    private async void GetHomePageDetails()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{App.BaseUrl}/Card/GetAllCards";

                // GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Cards = JsonConvert.DeserializeObject<List<CardModel>>(result);
                }
                else
                {
                    // Handle unsuccessful response
                }
            }
        }
        finally
        {
            // After fetching the data, set IsRefreshing to false
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task GotoDetailCardPage(int id)
    {
        //try
        //{
        DetailCardViewModel.Id = id;
        await Application.Current.MainPage.Navigation.PushAsync(new DetailCardView(new DetailCardViewModel()));
        //await Shell.Current.GoToAsync("DetailCardView");
        //}
        //catch(Exception ex)
        //{
        //    int x = 5;

        //}
    }
}

