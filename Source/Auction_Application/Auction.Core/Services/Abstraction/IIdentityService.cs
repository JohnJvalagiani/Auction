using Core.External.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(string Email, string Password);
        Task<AuthenticationResult> RegistrationAsync(string Email, string Password);
        Task<AuthenticationResult> LoginWithFacebookAsync(string accessToken);
        Task SignOutAsync();

    }
}
