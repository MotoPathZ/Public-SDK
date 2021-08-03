using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace MPZ.Config
{
    public class MPZConfigData { 
        [JsonProperty("Data")]public MPZConfig data;
        [JsonProperty("ApiToken")] public string api_token;
        [JsonProperty("Oauth2AccessData")] public Models.OAuth2AccessData oauth2AccessData;
    }

    public class MPZConfig
    {
        public enum AuthorizationType { API_Token, OAuth2 }
        [JsonProperty("AuthorizationType")]
        public AuthorizationType authType;
        [JsonProperty("UserAuthorizationData")]
        public UserAuthConfig UserAuthorization;
        [JsonProperty("OAuth2Data")]
        public OAuth2Config OAuth2;
        public class UserAuthConfig
        {
            [JsonProperty("Username")]
            public string username;
            [JsonProperty("Password")]
            public string password;
        }
        public class OAuth2Config
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
