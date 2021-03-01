using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class MPZConfig
    {
        public float timeForResponce;
        public enum AuthType /* Password -> FOR DEVELOPER`S Moto Path Z.*/
        {
            Application,
            Guide,
            User,
            Password, 
        }
        public AuthType authorizationType;
        public ApplicationAuthConfig ApplicationAuthorizationConfig;
        public GuideAuthConfig       GuideAuthorizationConfig;
        public UserAuthConfig        UserAuthorizationConfig;
        public PasswordAuthConfig    PasswordAuthorizationConfig;

        public class ApplicationAuthConfig { public string appID, token; }
        public class GuideAuthConfig { public string guideID, guidePrivateKey; public int password; }
        public class UserAuthConfig { public string username, password; }
        public class PasswordAuthConfig { public string password, password_access; }
    }
}
