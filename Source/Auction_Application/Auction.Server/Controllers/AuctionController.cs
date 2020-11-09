using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Api.Cache;
using Auction.Api.Contracts;
using Auction.Api.Dtos;
using Auction.Core.Data.Entities;
using Auction.Server.Filters;
using AutoMapper;
using Core.Data.Entities;
using Core.Services;
using Core.Services.Abstraction;
using IG.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Auction.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuctionController : ControllerBase
    {
        private readonly UserManager<Trader> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepo<Lot> _lotRepo;
        private readonly IAuctionService _auctionService;

        public AuctionController(UserManager<Trader> userManager ,IMapper mapper , IAuctionService auctionService, IRepo<Lot> lotRepo)

        {
            _userManager = userManager;
            _mapper = mapper;
            _lotRepo = lotRepo;
            _auctionService = auctionService;

        }



        [HttpGet(ApiRoutes.Auction.GetLotDetails)]
        [Cached(600)]
        [ApiKeyAuth]
        public async Task<IActionResult> GetAuctionDetails([FromBody]Guid Id)
        {

           var result = await _lotRepo.GetById(Id);


            return Ok(result);
           
        }



        [HttpGet(ApiRoutes.Auction.GetAllLot)]
        [Cached(600)]
        public async Task<IActionResult> GetAllLot()
        {

            var result = await _lotRepo.GetAll();


            return Ok(result);

        }


        [HttpPost(ApiRoutes.Auction.LotRegistration)]
        public async Task<IActionResult> RegisterLot([FromBody]LotRegistrationDto lot)
        {


            var newLot=_mapper.Map<Lot>(lot);


            newLot.Trader = await _userManager.GetUserAsync(User);

            var result = await _auctionService.LotRegistration(newLot);

            return Ok(result);
        }



        [HttpPost(ApiRoutes.Auction.AddTraderHistory)]
        [Cached(600)]
        public async Task<IActionResult> AddTradeHistory([FromBody]TradeHistory tradeHistory)
        {

            var result=await _auctionService.AddTradeHistory(tradeHistory);

            return Ok(result);
        }


        [HttpDelete(ApiRoutes.Auction.AddTraderHistory)]
        [Cached(600)]
        public async Task<IActionResult> UpdateTradeHistory([FromBody] Guid tradeHistoryId)
        {

            var result = await _auctionService.CancelLastBid(tradeHistoryId);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
