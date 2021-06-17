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
        public static async Task<OAuth2AccessData> GetElibilityToken(
            MPZConfig.OAuth2Config auth2Config,MPZConfig.UserAuthConfig userAuth)
        {
                    MPZClient.Logger.Log("OAuth2 - GetElibilityToken");//Debug
                    return await GetElibilityToken(auth2Config, userAuth);
        }
        public static async Task<OAuth2AccessData> GetAuthUser(
            MPZConfig.OAuth2Config auth2Config,MPZConfig.UserAuthConfig userAuth)
        {
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    MPZClient.Logger.Log("OAuth2 - GetElibilityToken");//Debug
                    return await GetElibilityToken(client, auth2Config, userAuth);
                }
            }
        }
    }
}