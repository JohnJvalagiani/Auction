using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api
{
    public interface IResponseCachService
    {
        Task CachResponseAsync(string cachKey, object response,TimeSpan timeTimeLive);
        Task<string> GetCachedResponseAsync(string cachKey);


    }
}
