using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Core.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }


    }
}