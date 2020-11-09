using Auction.Api.Installers;
using Auction.Server.Profiles;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Server.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddAutoMapper(typeof(AutoMapping));


        }
    }
}
