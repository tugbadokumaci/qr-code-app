using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrCodeApp.Api.Data;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyTypesController : Controller
    {
        private readonly MyDbContext _dbContext;

        public BodyTypesController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/CardModel
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardModel>>> GetCardModel()
        {
            return await _dbContext.Cards.ToListAsync();
        }
    }
}