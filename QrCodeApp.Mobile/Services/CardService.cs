﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Mobile.Services;

public class CardService
{
    private readonly String apiBaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7204" : "http://localhost:7204";

    public async Task<List<CardModel>> GetCardsAsync()
    {
        try
        {
#if DEBUG
            HttpClientHandler insecureHandler = GetInsecureHandler();
            using (HttpClient httpClient = new HttpClient(insecureHandler))
#else
#endif
            {
                var response = await httpClient.GetAsync($"{apiBaseUrl}/api/Cards/getAllCards");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CardModel>>(content);
                }
                else
                {
                    // Handle unsuccessful response
                    System.Diagnostics.Debug.WriteLine($"Failed to retrieve cards. Status code: {response.StatusCode}");
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception appropriately (e.g., log or display an error message)
            System.Diagnostics.Debug.WriteLine($"Error getting cards: {ex.Message}");
            return null;
        }
    }

    // Bu metodun platform projenizde olması gerekiyor
    private HttpClientHandler GetInsecureHandler()
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        return handler;
    }
}
