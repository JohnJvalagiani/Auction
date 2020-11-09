using Auction.Core.Data.Entities;
using Core.Data.Entities;
using Core.Services.Abstraction;
using IG.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Implementation
{
    public class AuctionService : IAuctionService
    {
        private readonly UserManager<Trader> _userManager;
        private readonly IRepo<Lot> _lotRepo;
        private readonly IRepo<TradeHistory> _tradeHistroryRepo;


        public AuctionService(UserManager<Trader> userManager ,IRepo<Lot> lotRepo, IRepo<TradeHistory> tradeHistroryRepo)
        {
            _userManager = userManager;
            _lotRepo = lotRepo;
            _tradeHistroryRepo = tradeHistroryRepo;
        }

        public async Task<TradeHistory> AddTradeHistory(TradeHistory tradeHistory)
        {

            var result=await _tradeHistroryRepo.Add(tradeHistory);

            return result;
        }

        public async Task<Lot> LotRegistration(Lot lot)
        {

            var result =await _lotRepo.Add(lot);
            return result;
        }
        public Task EndTrade()
        {
            throw new NotImplementedException();
        }

        public Task StartTrade()
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> CancelLastBid(Guid AuctionerId)
        {
           
            return await _tradeHistroryRepo.Remove(AuctionerId);
        }
    }
}
