using Auction.Core.Data.Databse;
using Core.Data.Entities;
using Core.Services;
using Core.Services.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Installers
{
    public class DbInstalle : IInstaller
    {
        public void InstallServices( IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IIdentityService, IdentityService>();


            services.AddDbContext<ApplicationDb>(options =>
          options.UseSqlServer(
          configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<Trader, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDb>()
            .AddDefaultTokenProviders();

        }
    }
}
