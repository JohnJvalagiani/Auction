using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Api.Contracts
{
    public static class ApiRoutes
    {
        public const string Base = "/api";


       public static class Auction
        {
         public const string StartAuction = Base + "/auction/start";
         public const string GetLotDetails = Base + "/auction/getlotdetails";
         public const string GetAllLot = Base + "/auction/getalllot";
         public const string AddTraderHistory = Base + "/auction/addtraderhistory";
         public const string LotRegistration = Base + "/auction/lotregistration";

        }



        public static class Identity
        {
            public const string Login= Base+"/identity/login";
            public const string Register = Base + "/identity/register";

        }


    }
}
