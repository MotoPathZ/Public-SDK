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
            MPZConfig.OAuth2Config oauth2Config,
            MPZConfig.UserAuthConfig userAuth
        )
        {
            MPZClient.Logger.Log("OAuth2Base - GetElibilityToken");
            MPZClient.Logger.Log("OAuth2Base - get link for get access token");

            string baseAddress = $"{EndPoints.OAUTH2}{EndPoints.OAUTH2_TOKEN}";
            MPZClient.Logger.Log("OAuth2Base - Base Address : " + baseAddress);

            string _grant_type = oauth2Config.grant_type.ToString();
            string _client_id = oauth2Config.client_id;
            string _client_secret = oauth2Config.client_secret;
            string _username = userAuth.username;
            string _password = userAuth.password;
            string _scope = oauth2Config.scope;

            MPZClient.Logger.Log("OAuth2Base - Send request for get token");
            MPZClient.Logger.Log("OAuth2Base - Send request data");

            OAuth2Data from = new OAuth2Data() { 
                grant_type = _grant_type,
                client_id = _client_id,
                client_secret = _client_secret,
                username = _username,
                password = _password,
                scope = _scope
            };
            string fromJson = JsonConvert.SerializeObject(from);
            var jsonContent = await MPZ.Tools.Networking.SendToServerForPost(EndPoints.OAUTH2, EndPoints.OAUTH2_TOKEN, fromJson);
            MPZClient.Logger.Log("OAuth2Base - Access Token Received!");
            OAuth2AccessData OAuth2Data = JsonConvert.DeserializeObject<OAuth2AccessData>(jsonContent);
            return OAuth2Data;
        }
        
    }
}