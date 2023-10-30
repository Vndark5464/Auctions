using System;
using Auctions.Models;
using OnlineAuction.Models;

namespace Auctions.Data.Services
{
    public interface IBidsService
    {
        Task Add(Bid bid);
        IQueryable<Bid> GetAll();
    }
}
