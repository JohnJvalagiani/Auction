using Auction.Core.Data.Entities;
using Auction.Server.Options;
using Core.Data.Entities;
using Core.External.Contacts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Implementation
{
    public class IdentityService : IIdentityService
    {
        private readonly JwtSettings _jwtSettings;

        private readonly UserManager<Trader> _userManager;

        private readonly IFacebookAuthService _facebookAuthService;

        private readonly SignInManager<Trader> _signInManager;

        public IdentityService(JwtSettings jwtSettings,UserManager<Trader> userManager, SignInManager<Trader> signinManager, IFacebookAuthService facebookAuthService)
        {

            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _facebookAuthService = facebookAuthService;
            _signInManager = signinManager;
        }

        public async Task<AuthenticationResult> LoginAsync(string Email, string Password)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {


                return new AuthenticationResult
                {
                    Errors = new string[] { $"User with this email adress {Email} already exits" }
                };
            }

            await _signInManager.SignInAsync(user,false);

            return await GenerateAuthenicationResultForUser(user);
        }

        public async Task<AuthenticationResult> LoginWithFacebookAsync(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);


            if (user == null)
            {
                var newUser = new Trader
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = Email,
                    UserName = Email
                };

                var createdResult = await _userManager.CreateAsync(newUser);

                if (!createdResult.Succeeded)
                {
                    return null;
                }


                return await GenerateAuthenicationResultForUser(newUser);
            }

            return await GenerateAuthenicationResultForUser(user);


        }


        public async Task<AuthenticationResult> RegistrationAsync(string Email, string Password)
        {

            var user =await  _userManager.FindByEmailAsync(Email);


            if (user != null)
            {
                return new AuthenticationResult
                {
                    Errors = new string[] { $"User with this email adress {Email} already exits" }
                };
            }
                var newUser = new Trader
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = Email,
                    UserName = Email
                };

                var createdResult = await _userManager.CreateAsync(newUser);

                if (!createdResult.Succeeded)
                {
                    return null;
                }


                return await GenerateAuthenicationResultForUser(newUser);
            
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();

        }

        private Task<AuthenticationResult> GenerateAuthenicationResultForUser(Trader theuser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: theuser.Email),
                    new Claim(type: JwtRegisteredClaimNames.Email, value: theuser.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(type: "id", value: theuser.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)

            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new AuthenticationResult
            {

                Saccess = true,
                Token = tokenHandler.WriteToken(token).ToString(),


            });
        }

    }
}
