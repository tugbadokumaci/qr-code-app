using System;
using QrCodeApp.Api.Data;
using QrCodeApp.Api.Repositories.Abstract;
using QrCodeApp.Api.Repositories.Concrete.Common;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Api.Repositories.Concrete;

public class CardModelRepository : GenericRepository<CardModel>, ICardModelRepository
{
    public CardModelRepository(MyDbContext context) : base(context)
    {
    }
}

