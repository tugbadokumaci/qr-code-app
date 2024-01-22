using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using QrCodeApp.Mobile.Views;
using QrCodeApp.Shared.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace QrCodeApp.Mobile.ViewModels;

public partial class SavedViewModel : ObservableObject
{
    [ObservableProperty]
    private SavedModel _model;

    private bool isRefreshing;
    public bool IsRefreshing
    {
        get => isRefreshing;
        set => SetProperty(ref isRefreshing, value);
    }


    public Command RefreshCommand { get; set; }

    private ObservableCollection<CardModel> cards;

    public ObservableCollection<CardModel> Cards
    {
        get => cards;
        set => SetProperty(ref cards, value);
    }



    public SavedViewModel()
    {
        SelectCommand = new Command(async () => await Selected());
        RefreshCommand = new Command(() => OnRefresh());
        Cards = new ObservableCollection<CardModel>();
       GetSavedPageDetails();
    }

    private void OnRefresh()
    {
        // Your logic to refresh the data
        GetSavedPageDetails();
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


    private async void GetSavedPageDetails()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{App.BaseUrl}/Card/GetSavedCards/00883398-4f3c-48fa-83de-722e9305b0a9";

                // GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<SavedModel> SavedModelList = JsonConvert.DeserializeObject<List<SavedModel>>(result);
                    Cards.Clear();
                    foreach (var savedModel in SavedModelList)
                    {
                        // Assuming there is another API endpoint to get CardModel details by Id
                        string cardApiUrl = $"{App.BaseUrl}/Card/GetCardDetails/{savedModel.CardId}";
                        HttpResponseMessage cardResponse = await client.GetAsync(cardApiUrl);

                        if (cardResponse.IsSuccessStatusCode)
                        {
                            string cardResult = await cardResponse.Content.ReadAsStringAsync();
                            CardModel cardModel = JsonConvert.DeserializeObject<CardModel>(cardResult);

                            // Set IsRefreshing to false right before adding to the collection
                            IsRefreshing = false;

                            // Add the cardModel to the ObservableCollection
                            Cards.Add(cardModel);
                        }
                        else
                        {
                            // Handle unsuccessful card response
                        }
                    }
                }
                else
                {
                    // Handle unsuccessful response
                }
            }
        }
        finally
        {
            // If there are no items fetched, set IsRefreshing to false
            if (Cards.Count == 0)
            {
                IsRefreshing = false;
            }
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
