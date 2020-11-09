using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.Entities
{

 public  class Trader : IdentityUser
    {

        public LegalForm LegalForm { get; set; }
        public long Swift { get; set; }
        public string Bank { get; set; }
        public string IBAN { get; set; }
        public string AuctionParticipateDate { get; set; }


    }

    public enum LegalForm
    {
        Physical,LegalPerson
    }
}
