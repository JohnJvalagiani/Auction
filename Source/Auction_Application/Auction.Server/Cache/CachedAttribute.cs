using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Api.Cache
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {

        private readonly int _timeToLiveSeconds;

        public CachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var cachSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();

            if (!cachSettings.Enabled)
            {
                await next();
                return;
            }

            var cachService = context.HttpContext.RequestServices.GetRequiredService<IResponseCachService>();

            var cachKey = GenerateCachKeyFromRequest(context.HttpContext.Request);

            var cachedResponse = await cachService.GetCachedResponseAsync(cachKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200

                };

                context.Result = contentResult;
                return;


            }


            var executedContext=await next();


            if (executedContext.Result is OkObjectResult objectResult)
            {

                await cachService.CachResponseAsync(cachKey, objectResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));


            }

        }

        private string GenerateCachKeyFromRequest(HttpRequest httpRequest)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{httpRequest.Path}");


            foreach (var (key,value) in httpRequest.Query.OrderBy(x=>x.Key))
            {

                keyBuilder.Append($"|{key}-{value}");


            }

            return keyBuilder.ToString();
        }
    }
}
