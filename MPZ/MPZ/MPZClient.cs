using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MPZ.Config;
using MPZ.Services;
using Newtonsoft.Json;

namespace MPZ
{
    public class MPZClient
    {
        public bool isAuth;
        public static Tools.ConfigManager config;
        public static Tools.Logger Logger;
        public MPZClient(MPZConfigData cfg = null)
        {
            Console.WriteLine("Initialization");
            Console.WriteLine("Initialization Logget");
            Logger = new Tools.Logger(Tools.Logger.LogType.Errors);
            Logger.Log("Logget Init");

            Init(cfg);
        }
        private async void Init(MPZConfigData cfg = null)
        {
            Logger.Log("Initialization Config");
            config = new Tools.ConfigManager();
            if (cfg != null)
            {
                Logger.Log("Loading configuration data from MPZClient");
                config.data = cfg;
                config.ConfigSave();
            }
            else { config.LoadConfig(); }

            await Services.Auth.AuthManager.Authorization();
            config.ConfigSave();

        }

        public async Task<Models.MPZUser> ShowAuthUser()
        {
            Logger.Log("MPZClient - OAuth2, API Token and User - ShowAuthUser (Search for the user who owns the access token)");
            if (config.data.authType == MPZConfigData.AuthorizationType.OAuth2)
                return await OAuth2GetUser();
            else if (config.data.authType == MPZConfigData.AuthorizationType.Token)
                return await APITokenGetUser();
            else
                return null;
        }
        private async Task<Models.MPZUser> OAuth2GetUser()
        {
            Logger.Log("MPZClient - OAuth2 and User - OAuth2GetUser (Search for the user who owns the access token)");

            return await Task.FromResult(await UserController.ShowOAuth2AuthorizationAsync());
        }
        private async Task<Models.MPZUser> APITokenGetUser()
        {
            Logger.Log("MPZClient - OAuth2 and User - OAuth2GetUser (Search for the user who owns the access token)");

            return await Task.FromResult(await UserController.ShowOAuth2AuthorizationAsync());
        }
        public async Task<Models.MPZUser> GetUserByID(uint user_id)
        { 
            Logger.Log("MPZClient - GetUserByID (Search for a user by ID)");

            return await Task.FromResult(await UserController.ShowByIdAsync(user_id));
        }
    }
}