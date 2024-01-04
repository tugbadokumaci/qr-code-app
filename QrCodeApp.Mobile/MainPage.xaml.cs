using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace QrCodeApp.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("http://10.0.2.2:5042/WeatherForecast");

                response.EnsureSuccessStatusCode(); // Ensure the request was successful (status code in the 2xx range).

                var data = await response.Content.ReadAsStringAsync();
                // Do something with the data.
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
