using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using QrCodeApp.Mobile.Views;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Mobile.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private System.Collections.IEnumerable cards;

        public System.Collections.IEnumerable Cards
        {
            get => cards;
            set => SetProperty(ref cards, value);
        }



        public HomeViewModel()
        {
            GetHomePageDetails();

        }

        private async void GetHomePageDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{App.BaseUrl}/Card/GetAllCards";

                // GET isteği oluştur
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Cards = JsonConvert.DeserializeObject<List<CardModel>>(result);
                }
                else
                {
                    // Handle unsuccessful response for tasks
                }
            }

        }

        [RelayCommand]
        public async Task GotoDetailCardPage(int id)
        {
            //try
            //{
            DetailCardViewModel.Id = id;
            await Shell.Current.GoToAsync($"//{nameof(AddCardView)}");
            //await Shell.Current.GoToAsync("DetailCardView");
            //}
            //catch(Exception ex)
            //{
            //    int x = 5;

            //}
        }
    }
}

