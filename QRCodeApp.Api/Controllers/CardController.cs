using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrCodeApp.Api.Data;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public CardController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllCards")]
        public IActionResult GetAllCards()
        {
            try
            {
                var allCards = _dbContext.Cards.ToList();
                return Ok(allCards);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("getUserCards/{userId}")]
        public IActionResult GetUserCards(int userId)
        {
            try
            {
                var userCards = _dbContext.Cards.Where(c => c.CreatorId == userId).ToList();
                return Ok(userCards);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("getCardDetails/{cardId}")]
        public IActionResult GetCardDetails(int userId, int cardId)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(c => c.CardId == cardId && c.CreatorId == userId);

                if (card == null)
                    return NotFound("Card not found.");

                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("createCardByUserId/{userId}")]
        public IActionResult CreateCard(int userId, [FromBody] CardModel newCard)
        {
            try
            {
                newCard.CreatorId = userId;
                _dbContext.Cards.Add(newCard);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetCardDetails), new { userId, cardId = newCard.CardId }, newCard);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("updateCard/{cardId}")]
        public IActionResult UpdateCard(int userId, int cardId, [FromBody] CardModel updatedCard)
        {
            try
            {
                var existingCard = _dbContext.Cards.FirstOrDefault(c => c.CardId == cardId && c.CreatorId == userId);

                if (existingCard == null)
                    return NotFound("Card not found.");

                existingCard.CardTitle = updatedCard.CardTitle;
                existingCard.CardDescription = updatedCard.CardDescription;

                _dbContext.SaveChanges();

                return Ok(existingCard);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteCard/{cardId}")]
        public IActionResult DeleteCard(int userId, int cardId)
        {
            try
            {
                var cardToDelete = _dbContext.Cards.FirstOrDefault(c => c.CardId == cardId && c.CreatorId == userId);

                if (cardToDelete == null)
                    return NotFound("Card not found.");

                _dbContext.Cards.Remove(cardToDelete);
                _dbContext.SaveChanges();

                return Ok($"Card with ID {cardId} has been deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
