using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace MPZ.Config
{
    public class MPZConfigData
    {
        public enum AuthorizationType { User, Token, OAuth2 }
        [JsonProperty("AuthorizationType")]
        public AuthorizationType authType;
        [JsonProperty("UserAuthorizationData")]
        public UserAuthData UserAuthorizationData;
        [JsonProperty("OAuth2AuthorizationData")]
        public OAuth2AuthData OAuth2AuthorizationData;
        //ACCESS
        [JsonProperty("TokenData")] 
        public Models.Other.Authorization.TokenData tokenData;
        [JsonProperty("Oauth2AccessData")] 
        public Models.Other.Authorization.OAuth2AccessData oauth2AccessData;
        public class UserAuthData
        {
            //[JsonProperty("username")]
            [JsonProperty("email")]
            public string username;
            [JsonProperty("password")]
            public string password;
        }
        public class OAuth2AuthData
        {
            public enum grantType { client_credentials, password }
            [JsonProperty("GrantType")]
            public grantType grant_type;
            [JsonProperty("ClientId")]
            public string client_id;
            [JsonProperty("ClientSecret")]
            public string client_secret;
            [JsonProperty("Scope")]
            public string scope;
        }
    }
}
