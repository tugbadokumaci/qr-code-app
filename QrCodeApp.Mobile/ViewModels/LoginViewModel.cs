using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using QrCodeApp.Mobile.ViewModels.Common;
using Newtonsoft.Json;
using static Android.Graphics.ColorSpace;
using Xamarin.KotlinX.Coroutines.Scheduling;
using QrCodeApp.Shared.Models;
using QrCodeApp.Mobile.Views;

namespace QrCodeApp.Mobile.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    public LoginViewModel()
    {
    }


    private string _email;
    private string _password;

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    [RelayCommand]
    private async Task Login()
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"{App.BaseUrl}/Users/Login";

            // POST isteği oluştur
            var requestBody = new
            {
                Email = _email,
                Password = _password
            };

            var jsonRequest = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                UserModel user = JsonConvert.DeserializeObject<UserModel>(result);

                if (user != null)
                {
                    // Başarılı giriş durumu
                    //Content = "Successfully logged in";
                    //await _navigation.PushAsync(new HomeView(new HomeViewModel()));
                    await Shell.Current.GoToAsync(nameof(HomeView));


                }
                else
                {
                    // Kullanıcı bilgileri doğrulanamadı
                    //Content = "Credentials are incorrect";
                }
            }
            else
            {
                // Handle unsuccessful response
                //Content = "Login failed. Please try again.";
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            //Content = ex.Message;
        }
    }

}



