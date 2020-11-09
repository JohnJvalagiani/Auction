using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Api.Contracts;
using Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<ActionResult> Login(string Email,string Password)
        {

            var result=await _identityService.LoginAsync(Email,Password);

            if(!result.Saccess)
            {

                return BadRequest(result.Errors);


            }

            return Ok(result.Token);

        }
        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<ActionResult> Registration(string Email, string Password)
        {

            var result = await _identityService.RegistrationAsync(Email, Password);

            if (!result.Saccess)
            {

                return BadRequest(result.Errors);


            }

            return Ok(result.Token);

        }
        //[HttpPost]
        //public async Task<ActionResult> LoginWithFacebook(string Email, string Password)
        //{

        //    var result = await _identityService.LoginWithFacebookAsync(Email);

        //    if (!result.Saccess)
        //    {

        //        return BadRequest(result.Errors);


        //    }

        //    return Ok(result.Token);

        //}
        [HttpGet]
        public async Task<ActionResult> LogOut()
        {

           await _identityService.SignOutAsync();

            return Ok();

        }


    }
}
