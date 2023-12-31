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

        [HttpGet("getUserCards/{Id}")]
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

        [HttpGet("getCardDetails/{Id}")]
        public IActionResult GetCardDetails( int Id)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(c => c.Id == Id);

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
                return CreatedAtAction(nameof(GetCardDetails), new { userId, Id = newCard.Id }, newCard);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("updateCard/{Id}")]
        public IActionResult UpdateCard(int userId, int Id, [FromBody] CardModel updatedCard)
        {
            try
            {
                var existingCard = _dbContext.Cards.FirstOrDefault(c => c.Id == Id && c.CreatorId == userId);

                if (existingCard == null)
                    return NotFound("Card not found.");

                existingCard.DisplayName = updatedCard.DisplayName;
                existingCard.JobTitle = updatedCard.JobTitle;
                existingCard.Phone = updatedCard.Phone;
                existingCard.Mail = updatedCard.Mail;
                existingCard.WebsiteUrl = updatedCard.WebsiteUrl;
                existingCard.Address = updatedCard.Address;
                existingCard.WebsiteUrl = updatedCard.WebsiteUrl;
                existingCard.CreatedDate = updatedCard.CreatedDate;
                existingCard.IsActive = updatedCard.IsActive;

                _dbContext.SaveChanges();

                return Ok(existingCard);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("deleteCard/{Id}")]
        public IActionResult DeleteCard(int userId, int Id)
        {
            try
            {
                var cardToDelete = _dbContext.Cards.FirstOrDefault(c => c.Id == Id && c.CreatorId == userId);

                if (cardToDelete == null)
                    return NotFound("Card not found.");

                _dbContext.Cards.Remove(cardToDelete);
                _dbContext.SaveChanges();

                return Ok($"Card with ID {Id} has been deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
