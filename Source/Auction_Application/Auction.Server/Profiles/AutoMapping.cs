using Auction.Api.Dtos;
using Auction.Core.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Server.Profiles
{
    public class AutoMapping:Profile
    {

        public AutoMapping()
        {

            CreateMap<Lot,LotRegistrationDto>().ReverseMap();

        }


    }
}
