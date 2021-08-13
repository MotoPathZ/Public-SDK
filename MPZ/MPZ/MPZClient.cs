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
            Console.WriteLine("Initialization Logger");
            //Logger = new Tools.Logger(Tools.Logger.LogType.Debug);
            Logger = new Tools.Logger();
            Logger.Log("Logger Init");
            Init(cfg);
        }
        private void Init(MPZConfigData cfg = null)
        {
            Logger.Log("Initialization Config");
            config = new Tools.ConfigManager();
            if (cfg != null)
            {
                config.data = cfg;
                config.ConfigSave();
            }
            else { config.LoadConfig(); }

            MPZClient.Logger.Debug("Authorization");
            Services.Auth.AuthManager.Authorization();
            MPZClient.Logger.Debug("Authorization");

            config.ConfigSave();
        }

        public Models.MPZUser ShowAuthUser()
        {
            Logger.Log("MPZClient - OAuth2, API Token and User - ShowAuthUser (Search for the user who owns the access token)");
            return Services.Auth.AuthManager.ShowUserAuthorizationAsync().Result;
        }
        public async Task<Models.MPZUser> GetUserByID(uint user_id)
        { 
            Logger.Log("MPZClient - GetUserByID (Search for a user by ID)");

            return await Task.FromResult(await UserController.ShowByIdAsync(user_id));
        }
    }
}