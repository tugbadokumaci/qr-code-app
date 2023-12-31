using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using QrCodeApp.Mobile.ViewModels.Common;
using QrCodeApp.Shared.Models;
using System.Text;
using CommunityToolkit.Maui.Core;

namespace QrCodeApp.Mobile.ViewModels
{
    public partial class SignupViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _userSurname;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _passwordHash;

        [RelayCommand]
        public async Task Signup()
        {
            string message = string.Empty;

            UserModel model = new()
            {
                UserName = UserName,
                UserSurname = UserSurname,
                Email = Email,
                PasswordHash = PasswordHash,
            };

            try
            {
                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                var json = System.Text.Json.JsonSerializer.Serialize(model, jsonSerializerOptions);

                var httpClient = new HttpClient();
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.PostAsync($"{App.BaseUrl}/PostUser", stringContent);

                if (response != null && response.IsSuccessStatusCode)
                {
                    message = "User registered successfully!";
                }
                else
                {
                    message = "Failed to register user.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing object to JSON or sending request: {ex.Message}");
                message = "An error occurred while registering the user.";
            }

            SemanticScreenReader.Announce(message);
            await CommunityToolkit.Maui.Alerts.Toast.Make(message, ToastDuration.Long, 16).Show(new CancellationTokenSource().Token);

            // Use navigation service to navigate to the main page if needed.
            // App.Current.MainPage = new AppShell();
        }

        // ColorSelected metodu ViewModel içinde kullanılmıyor, bu nedenle kaldırıldı.
    }
}
