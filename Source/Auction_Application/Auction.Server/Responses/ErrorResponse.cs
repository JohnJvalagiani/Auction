using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Responses
{
    public class ErrorResponse
    {

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

    }
}
