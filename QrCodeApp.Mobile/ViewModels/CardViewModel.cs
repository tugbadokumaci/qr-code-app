using System.Collections.ObjectModel;
using System.Linq;
using QrCodeApp.Mobile.Services;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Mobile.ViewModels
{
    public class CardViewModel
    {
        private readonly CardService _cardService;

        public ObservableCollection<CardModel> Cards { get; set; } = new ObservableCollection<CardModel>();

        public CardViewModel(CardService cardService)
        {
            _cardService = cardService;

            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var cards = await _cardService.GetCardsAsync();
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }
    }
}
