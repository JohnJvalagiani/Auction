using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Auction.Core.Data.Entities
{
    public class Lot:BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public decimal StartPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal MinBid { get; set; }
        public int BidsCount { get; set; }
        public DateTime AuctionDate { get; set; }
        public string TraderId { get; set; }
        [ForeignKey(nameof(TraderId))]
        public Trader Trader { get; set; }



    }
}
