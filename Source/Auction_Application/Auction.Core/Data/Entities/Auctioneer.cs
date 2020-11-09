using Microsoft.AspNetCore.Identity;
using System;

namespace Auction.Core.Data.Entities
{
    public class Auctioneer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}