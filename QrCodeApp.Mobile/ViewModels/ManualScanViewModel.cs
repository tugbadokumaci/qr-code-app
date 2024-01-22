using CommunityToolkit.Maui.Core;
using System.Net.Http.Headers;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrCodeApp.Shared.Models;
using System.Text;
using QrCodeApp.Mobile.Views;

namespace QrCodeApp.Mobile.ViewModels;

public partial class ManualScanViewModel : ObservableObject
{
    [ObservableProperty]
    public string _userId = "00883398-4f3c-48fa-83de-722e9305b0a9";
    [ObservableProperty]
    public int _cardId;

    [ObservableProperty]
    private SavedModel _model;

    public ManualScanViewModel()
    {
        _model = new SavedModel { UserId = "00883398-4f3c-48fa-83de-722e9305b0a9" };
    }

    [RelayCommand]
    public async Task ScanCardManually(int cardId)
    {
        Console.WriteLine(_model.ToString());

        string message = string.Empty;
        _model.UserId = _userId;  // Set the UserId property of _model

        _model.CardId = cardId;

        try
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var json = System.Text.Json.JsonSerializer.Serialize(_model, jsonSerializerOptions);

            var httpClient = new HttpClient();
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync($"{App.BaseUrl}/Card/SaveCard", stringContent);

            if (response != null && response.IsSuccessStatusCode)
            {
                //message = "Card saved!";
                //await Application.Current.MainPage.Navigation.PushAsync(new ScanSuccessfulView());

            }
            else
            {
                message = "Card couldn't be saved. Check your connection and try again.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error serializing object to JSON or sending request: {ex.Message}");
            message = "An error occurred while saving the task.";
        }

        SemanticScreenReader.Announce(message);
        await CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Long, 16).Show(new CancellationTokenSource().Token);
    }
}
