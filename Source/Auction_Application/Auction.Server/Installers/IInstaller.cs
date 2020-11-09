using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Installers
{
   public  interface IInstaller
    {
        void InstallServices( IServiceCollection serviceCollection, IConfiguration configuration);

    }
}
