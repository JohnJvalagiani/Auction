using Core.External.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
   public interface IFacebookAuthService
    {

        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);


    }
}
