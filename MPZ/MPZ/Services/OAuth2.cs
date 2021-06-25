using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using MPZ.Models;
using MPZ.Config;

namespace MPZ.Services
{
    public class OAuth2 : OAuth2Base
    {
        /* Use UserContoller@ShowOAuth2AuthorizationAsync
        public static async Task<User> GetAuthUser(string access_token)
        {
            MPZClient.Logger.Log("OAuth2 - GetAuthUser");
            return null;
        }*/
    }
}