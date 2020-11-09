using Auction.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstraction
{

   public interface IAuctionService
    {

        Task<Lot> LotRegistration(Lot lot);
        Task<TradeHistory> AddTradeHistory(TradeHistory tradeHistory);
        Task StartTrade();
        Task EndTrade();
        Task<bool> CancelLastBid(Guid AuctionerId);

    }
}
