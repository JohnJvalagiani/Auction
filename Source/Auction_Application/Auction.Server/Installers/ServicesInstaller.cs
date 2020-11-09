using Auction.Api.Installers;
using Auction.Core.Data.Entities;
using Core.Services;
using Core.Services.Abstraction;
using Core.Services.Implementation;
using IG.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Server.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IRepo<Lot>, Repo<Lot>>();
            serviceCollection.AddScoped<IRepo<TradeHistory>, Repo<TradeHistory>>();
            serviceCollection.AddScoped<IAuctionService, AuctionService>();
            serviceCollection.AddScoped<IFacebookAuthService, FacebookAuthService>();
        }
    }
}
