using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class MPZConfigData { public MPZConfig dataConfig; public Models.OAuth2AccessData accessData; }

    public class MPZConfig
    {
        public float maxTimeForResponce = 10f; //10 second

        public enum APIversions { main, alpha }
        public APIversions APIVersion = APIversions.main;
        
        public OAuth2Config   OAuth2;
        public UserAuthConfig UserAuthorization;

        public class OAuth2Config { 
            public enum grantType {client_credentials,password}
            public grantType grant_type;
            public string client_id, client_secret, scope;
        }
        public class UserAuthConfig { public string username, password; }
    }
}
