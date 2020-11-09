using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Core.Data.Entities
{
   public  class TradeHistory:BaseEntity
    {
        public Lot Lot { get; set; }
        public Trader Trader { get; set; }
        public Auctioneer Auctioneer { get; set; }
        public DateTime Date { get; set; }
    
    }
}
