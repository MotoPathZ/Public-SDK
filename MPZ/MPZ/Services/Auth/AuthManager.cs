using MPZ.Config;
using MPZ.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPZ.Services.Auth
{
    public class AuthManager
    {
        #region Authorization
        public static void Authorization()
        {

            MPZClient.Logger.Log($"MPZClient - AuthManager - Authorization() - Auth Type = {MPZClient.config.data.authType}");


            switch (MPZClient.config.data.authType)
            {
                case MPZConfigData.AuthorizationType.OAuth2:
                    MPZClient.config.data.oauth2AccessData = OAuth2Auth();
                    break;
                case MPZConfigData.AuthorizationType.User:
                    if (Tools.CheckingIsNull(MPZClient.config.data.tokenData) || Tools.CheckingIsNull(MPZClient.config.data.tokenData.accessToken))
                    {
                        MPZClient.Logger.Log("if (!Tools.CheckingIsNull(MPZClient.config.data.tokenData))");
                        MPZClient.config.data.tokenData = UserAuth();
                    }
                    else
                    {
                        if (Tools.CheckingLifeTokenUseDate(MPZClient.config.data.tokenData.token.expires_at))
                        {
                            MPZClient.Logger.Log("if (Tools.CheckingLifeTokenUseDate(MPZClient.config.data.tokenData.token.expires_at))");
                            MPZClient.config.data.tokenData = UserAuth();
                        }
                    }
                    break;
                case MPZConfigData.AuthorizationType.Token:
                    //Если AuthorizationType = Token, то это значит, что человек уже авторизован и в конфеге прописан токен.
                    break;
            }

            //MPZClient.config.ConfigSave(); //Save in MPZClient (Init)
        }

        private static Models.Other.Authorization.TokenData UserAuth()
        {
            MPZClient.Logger.Log("The access token for API Token was not found or the config was updated");
            //
            return UserAuthBase();
        }
        private static Models.Other.Authorization.TokenData UserAuthBase()
        {
            return UserToken.GetElibilityToken(MPZClient.config.data.UserAuthorizationData).Result;
        }

        private static Models.Other.Authorization.OAuth2AccessData OAuth2Auth()
        {
            MPZClient.Logger.Log("The access token for OAuth2 was not found or the config was updated");
            //
            return OAuth2AuthBase(MPZClient.config.data);
        }
        private static Models.Other.Authorization.OAuth2AccessData OAuth2AuthBase(MPZConfigData cfgData)
        {
            MPZClient.Logger.Log("MPZClient - AuthManager - OAuth2GetToken");
            return OAuth2.GetElibilityToken(cfgData.OAuth2AuthorizationData, cfgData.UserAuthorizationData).Result;
        }

        #endregion

        public static string GetToken()
        {
            switch (MPZClient.config.data.authType)
            {
                case MPZConfigData.AuthorizationType.OAuth2:
                    if (Tools.CheckingIsNull(MPZClient.config.data.oauth2AccessData)) return "";
                    return MPZClient.config.data.oauth2AccessData.AccessToken;
                case MPZConfigData.AuthorizationType.User:
                    if (Tools.CheckingIsNull(MPZClient.config.data.tokenData)) return "";
                    return MPZClient.config.data.tokenData.accessToken;
                case MPZConfigData.AuthorizationType.Token:
                    if (Tools.CheckingIsNull(MPZClient.config.data.tokenData)) return "";
                    return MPZClient.config.data.tokenData.accessToken;
                default:
                    if (Tools.CheckingIsNull(MPZClient.config.data.tokenData)) return "";
                    return MPZClient.config.data.tokenData.accessToken;
            }
        }

        public static async Task<MPZUser> ShowUserAuthorizationAsync()
        {
            MPZClient.Logger.Log($"AuthManager - ShowUserAuthorizationAsync");
            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.auth_user);
            try
            {
                var user = JsonConvert.DeserializeObject<MPZUser>(json);
                if (user!=null) return user;
                return new MPZUser();
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"AuthManager - ShowUserAuthorizationAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZUser();
            }
        }
    }
}
