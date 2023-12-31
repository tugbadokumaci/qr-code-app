using System;
using CommunityToolkit.Maui.Core;
using System.Net.Http.Headers;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using static Android.Graphics.ColorSpace;
using QrCodeApp.Shared.Models;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeApp.Mobile.ViewModels;

public partial class DetailCardViewModel : ObservableObject

{
    public static int Id { get; set; }


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
    private DateTime _date; // creation date

    [ObservableProperty]
    private TimeSpan _time; // creation time

    [ObservableProperty]
    private CardModel _model;


    private bool _isEditMode;
    public bool IsEditMode
    {
        get => _isEditMode;
        set => SetProperty(ref _isEditMode, value);
    }

    public DetailCardViewModel()
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
            CardModel Model = JsonConvert.DeserializeObject<CardModel>(result);

            DisplayName = Model.DisplayName;
            JobTitle = Model.JobTitle;
            Phone = Model.Phone;
            Mail = Model.Mail;
            WebsiteUrl = Model.WebsiteUrl;
            Address = Model.Address;
            Date = Model.CreatedDate.Date;
            Time = Model.CreatedDate.TimeOfDay;

        }
        else
        {
            // Handle unsuccessful response for tasks
        }
    }

    [RelayCommand]
    public async Task Save()
    {
        string message = string.Empty;

        Model.DisplayName = _displayName;
        Model.JobTitle = _jobTitle;
        Model.Phone = _phone;
        Model.Mail = _mail;
        Model.WebsiteUrl = _websiteUrl;
        Model.Address = _address;
        Model.CreatedDate = DateTime.Parse(_date.ToShortDateString() + " " + _time.ToString());



        try
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Use CamelCase naming policy
                WriteIndented = true, // Optionally set this to true for indented JSON
            };
            //string json = JsonSerializer.Serialize(model, jsonSerializerOptions);
            var json = System.Text.Json.JsonSerializer.Serialize(Model, jsonSerializerOptions);

            //string json = JsonConvert.DeserializeObject(model);
            var httpClient = new HttpClient();
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync($"{App.BaseUrl}/Card/updateCard/{Id}", stringContent);

            if (response != null && response.IsSuccessStatusCode)
            {
                message = "Card updated!";
            }
            else
            {
                message = "Card couldn't be updated. Check your connection and try again.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error serializing object to JSON or sending request: {ex.Message}");
            message = "An error occurred while saving the task.";
        }

        SemanticScreenReader.Announce(message);
        await CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Long, 16).Show(new CancellationTokenSource().Token);

        // Use navigation service to navigate to the main page if needed.
        // App.Current.MainPage = new AppShell();
    }

    [RelayCommand]
    public async Task Remove()
    {
        string message = string.Empty;

        Model.IsActive = false;
        Model.UpdatedDate = DateTime.Parse(_date.ToShortDateString() + " " + _time.ToString());



        try
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Use CamelCase naming policy
                WriteIndented = true, // Optionally set this to true for indented JSON
            };
            //string json = JsonSerializer.Serialize(model, jsonSerializerOptions);
            var json = System.Text.Json.JsonSerializer.Serialize(Model, jsonSerializerOptions);

            //string json = JsonConvert.DeserializeObject(model);
            var httpClient = new HttpClient();
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PutAsync($"{App.BaseUrl}/Card/updateCard/{Id}", stringContent);

            if (response != null && response.IsSuccessStatusCode)
            {
                message = "Card removed!";
            }
            else
            {
                message = "Card couldn't be removed. Check your connection and try again.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error serializing object to JSON or sending request: {ex.Message}");
            message = "An error occurred while saving the task.";
        }

        SemanticScreenReader.Announce(message);
        await CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Long, 25).Show(new CancellationTokenSource().Token);

        // Use navigation service to navigate to the main page if needed.
        // App.Current.MainPage = new AppShell();
    }

    [RelayCommand]
    public void ToggleEditMode()
    {
        IsEditMode = !IsEditMode;
    }
}

