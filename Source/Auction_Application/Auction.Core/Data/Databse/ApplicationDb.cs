using Auction.Core.Data.Entities;
using Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Core.Data.Databse
{
    public class ApplicationDb:IdentityDbContext<Trader>
    {

        public DbSet<Lot> Lots { get; set; }
        public DbSet<TradeHistory> TradeHistories { get; set; }



        public ApplicationDb(DbContextOptions options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
