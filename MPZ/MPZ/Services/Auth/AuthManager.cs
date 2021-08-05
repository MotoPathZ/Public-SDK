using MPZ.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPZ.Services.Auth
{
    public class AuthManager
    {
        #region Authorization
        public static async Task Authorization()
        {

            MPZClient.Logger.Log($"MPZClient - AuthManager - Authorization() - Auth Type = {MPZClient.config.data.authType}");
            if (MPZClient.config.data.authType == MPZConfigData.AuthorizationType.OAuth2)
            {
                MPZClient.config.data.oauth2AccessData = await OAuth2Auth();
            }

            if (MPZClient.config.data.authType == MPZConfigData.AuthorizationType.User)
            {
                if (MPZClient.config.data.tokenData.token == null)
                {
                    MPZClient.config.data.tokenData = await UserAuth();
                }
                else
                {
                    if (MPZClient.config.data.tokenData.token.expires_at < DateTime.Now.AddDays(-2))
                    {
                        MPZClient.config.data.tokenData = await UserAuth();
                    }

                }
            }
            if (MPZClient.config.data.authType == MPZConfigData.AuthorizationType.Token)
            {
                //Если AuthorizationType = Token, то это значит, что человек уже авторизован и в конфеге прописан токен.
            }

            //MPZClient.config.ConfigSave(); //Save in MPZClient (Init)
        }

        private static async Task<Models.Other.Authorization.TokenData> UserAuth()
        {
            MPZClient.Logger.Log("The access token for API Token was not found or the config was updated");
            return await UserAuthBase();
        }
        private static async Task<Models.Other.Authorization.TokenData> UserAuthBase()
        {
            return await Task.FromResult(await Auth.UserToken.GetElibilityToken(MPZClient.config.data.UserAuthorizationData));
        }

        private static async Task<Models.Other.Authorization.OAuth2AccessData> OAuth2Auth()
        {
            MPZClient.Logger.Log("The access token for OAuth2 was not found or the config was updated");
            return await OAuth2AuthBase(MPZClient.config.data);
        }
        private static async Task<Models.Other.Authorization.OAuth2AccessData> OAuth2AuthBase(MPZConfigData cfgData)
        {
            MPZClient.Logger.Log("MPZClient - AuthManager - OAuth2GetToken");
            return await Task.FromResult(await Auth.OAuth2.GetElibilityToken(cfgData.OAuth2AuthorizationData, cfgData.UserAuthorizationData));
        }

        #endregion

        public static string GetToken()
        {
            if (MPZClient.config.data.authType == MPZConfigData.AuthorizationType.OAuth2)
                return MPZClient.config.data.oauth2AccessData.AccessToken;
            else if (MPZClient.config.data.authType == MPZConfigData.AuthorizationType.Token)
                return MPZClient.config.data.tokenData.accessToken;
            else if (MPZClient.config.data.authType == MPZConfigData.AuthorizationType.User)
                return MPZClient.config.data.tokenData.accessToken;
            else return MPZClient.config.data.tokenData.accessToken;
        }
    }
}
