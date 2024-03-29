﻿using CommunityToolkit.Mvvm.Input;
using QrCodeApp.Mobile.ViewModels.Common;
using Newtonsoft.Json;
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
                    await Application.Current.MainPage.Navigation.PushAsync(new HomeView(new HomeViewModel()));

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

    [RelayCommand]
    public async Task GotoSignupPage()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new SignupView(new SignupViewModel()));
    }

}



