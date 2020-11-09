using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Services
{
    public class ResponesCacheServce : IResponseCachService
    {


        public Task CachResponseAsync(string cachKey, object response, TimeSpan timeTimeLive)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCachedResponseAsync(string cachKey)
        {
            throw new NotImplementedException();
        }
    }
}
