using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Core;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Mobile.ViewModels;

public partial class AddCardViewModel : ObservableObject
{

    [ObservableProperty]
    private int _creatorId;

    [ObservableProperty]
    private string _displayName;

    [ObservableProperty]
    private string _jobTitle;

    [ObservableProperty]
    private string _phone;

    [ObservableProperty]
    private string _mail;

    [ObservableProperty]
    private string _websiteUrl;

    [ObservableProperty]
    private string _address;

    [ObservableProperty]
    private DateTime _createdDate; // creation date

    [ObservableProperty]
    private CardModel _model;

    public AddCardViewModel()
    {
        _model = new CardModel();

    }

    [RelayCommand]
    public async Task Save()
    {
        Console.WriteLine(Model.ToString()); // Use _model instead of Model

        string message = string.Empty;
        Model.DisplayName = DisplayName;
        Model.JobTitle = JobTitle;
        Model.Phone = Phone;
        Model.Mail = Mail;
        Model.WebsiteUrl = WebsiteUrl;
        Model.Address = Address;
        Model.CreatedDate = CreatedDate;

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

            var response = await httpClient.PostAsync($"{App.BaseUrl}/Card/createCardByUserId/1", stringContent);

            if (response != null && response.IsSuccessStatusCode)
            {
                message = "Card created!";
            }
            else
            {
                message = "Card couldn't be created. Check your connection and try again.";
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