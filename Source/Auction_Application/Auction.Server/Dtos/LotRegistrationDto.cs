using Auction.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Dtos
{
    public class LotRegistrationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public decimal StartPrice { get; set; }
        public decimal MinBid { get; set; }
        public DateTime AuctionDate { get; set; }

    }
}
