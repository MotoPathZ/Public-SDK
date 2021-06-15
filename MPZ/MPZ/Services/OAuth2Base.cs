using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using MPZ.Config;
using MPZ.Models;


namespace MPZ.Services
{
    public class OAuth2Base
    {
        public static async Task<OAuth2AccessData> GetElibilityToken(
            HttpClient client,
            MPZConfig.OAuth2Config auth2Config,
            MPZConfig.UserAuthConfig userAuth
        )
        {
            MPZClient.Logger.Log("OAuth2Base - get link for get access token");

            string baseAddress = $"{EndPoints.OATH2_SERVER}{EndPoints.OATH2_TOKEN}";
            MPZClient.Logger.Log("OAuth2Base - Base Address : " + baseAddress);

            string _grant_type = auth2Config.grant_type.ToString();
            string _client_id = auth2Config.client_id;
            string _client_secret = auth2Config.client_secret;
            string _username = userAuth.username;
            string _password = userAuth.password;
            string _scope = auth2Config.scope;

            MPZClient.Logger.Log("OAuth2Base - Send request for get token");
            MPZClient.Logger.Log("OAuth2Base - Send request data");

            OAuth2Data from = new OAuth2Base.OAuth2Data() { 
                grant_type = _grant_type,
                client_id = _client_id,
                client_secret = _client_secret,
                username = _username,
                password = _password,
                scope = _scope
            };
            string fromJson = JsonConvert.SerializeObject(from);
            var jsonContent = await Tools.Networking.SendToServerForPost(EndPoints.OATH2_SERVER, EndPoints.OATH2_TOKEN, fromJson);
            MPZClient.Logger.Log("OAuth2Base - Access Token Received!");
            OAuth2AccessData OAuth2Data = JsonConvert.DeserializeObject<OAuth2AccessData>(jsonContent);
            return OAuth2Data;
        }
        private class OAuth2Data
        {
            public string grant_type;
            public string client_id;
            public string client_secret;
            public string username;
            public string password;
            public string scope;
        }
    }
}