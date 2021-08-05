using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MPZ.Config;
using MPZ.Models.Other.Authorization;


namespace MPZ.Services.Auth
{
    public class OAuth2Base
    {
        public static async Task<OAuth2AccessData> GetElibilityToken(
            MPZConfigData.OAuth2AuthData oauth2AuthData,
            MPZConfigData.UserAuthData userAuthData
        )
        {
            MPZClient.Logger.Log("OAuth2Base - GetElibilityToken");
            MPZClient.Logger.Log("OAuth2Base - get link for get access token");

            string baseAddress = $"{EndPoints.OAUTH2}{EndPoints.OAUTH2_TOKEN}";
            MPZClient.Logger.Log("OAuth2Base - Base Address : " + baseAddress);

            string _grant_type = oauth2AuthData.grant_type.ToString();
            string _client_id = oauth2AuthData.client_id;
            string _client_secret = oauth2AuthData.client_secret;
            string _username = userAuthData.username;
            string _password = userAuthData.password;
            string _scope = oauth2AuthData.scope;

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