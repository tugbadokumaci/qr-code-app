using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using QrCodeApp.Mobile;
using QrCodeApp.Shared.Models;

public class ShowQRCodeViewModel : ObservableObject
{
    private CardModel _model;

    public CardModel Model
    {
        get => _model;
        set => SetProperty(ref _model, value);
    }

    public ShowQRCodeViewModel()
    {
        GetModelDetails(1);
    }

    private async void GetModelDetails(int Id)
    {
        HttpClient httpClient = new HttpClient();

        string apiUrl = $"{App.BaseUrl}/Card/getCardDetails/{Id}";

        // GET isteği oluştur
        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            Model = JsonConvert.DeserializeObject<CardModel>(result);
        }
        else
        {
            // Handle unsuccessful response for tasks
        }
    }
}
