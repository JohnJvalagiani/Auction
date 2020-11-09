using Core.External.Contacts;
using Core.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "";
        private const string UserInfoUrl = "";
        private readonly FacebookAuthSettings _facebookAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;


        public FacebookAuthService(FacebookAuthSettings facebookAuthSettings, IHttpClientFactory httpClientFactory)
        {
            this._facebookAuthSettings = facebookAuthSettings;
            this._httpClientFactory = httpClientFactory;


        }


        public async  Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken)
        {
            var formatterurl = string.Format(UserInfoUrl, accessToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);
            var result = await _httpClientFactory.CreateClient().GetAsync(formatterurl);
            var responseAsStrng = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FacebookUserInfoResult>(responseAsStrng);


        }

        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formatterurl = string.Format(TokenValidationUrl, accessToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);
            var result = await _httpClientFactory.CreateClient().GetAsync(formatterurl);
            var responseAsStrng = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseAsStrng);

        }
    }
}
