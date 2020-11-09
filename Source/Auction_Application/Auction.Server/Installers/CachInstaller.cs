using Auction.Api.Cache;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Installers
{
    public class CachInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            var redisCachSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings )).Bind(redisCachSettings);
            services.AddSingleton(redisCachSettings);


        }
    }
}
