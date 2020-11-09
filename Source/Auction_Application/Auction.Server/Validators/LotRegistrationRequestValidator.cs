using Auction.Api.Dtos;
using Auction.Core.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Cache
{
    public class LotRegistrationRequestValidator:AbstractValidator<LotRegistrationDto>
    {
        public LotRegistrationRequestValidator()
        {
            RuleFor(x => x.StartPrice)
                .NotEmpty();
        }

    }
}
