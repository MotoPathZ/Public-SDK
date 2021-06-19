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
        public static Tools.Config config;
        public static Tools.Logger Logger;
        public Models.MPZUser user;
        public MPZClient(MPZConfig cfg = null)
        {
            Console.WriteLine("Initialization");
            Console.WriteLine("Initialization Logget");
            Logger = new Tools.Logger(Tools.Logger.LogType.Errors);
            Logger.Log("Logget Init");

            Init(cfg);
        }
        private async void Init(MPZConfig cfg = null)
        {
            Logger.Log("Initialization Config");
            config = new Tools.Config();

            config.LoadConfigAndOAuth2();

            if (cfg != null)
            {
                Logger.Log("Loading configuration data from MPZClient");
                config.data.dataConfig = cfg;
                config.ConfigAndOAuth2Save();
            }
            Logger.Log("Initialization Config OAuth2");
            if (config.data.accessData == null ||
                config.data.accessData.AccessToken == null ||
                config.data.accessData.AccessToken == "" ||
                cfg != null /*&& cfg != config.data.dataConfig*/
                )
            {
                Logger.Log("The access token for OAuth2 was not found or the config was updated");
                var oAuth2AccessData = await OAuth2GetToken(config.data.dataConfig);
                config.data.accessData = oAuth2AccessData;
                Logger.Log("OAuth2 Token");
                Logger.Log(config.data.accessData.AccessToken);
                config.ConfigAndOAuth2Save();
            }
            //user = 
        }
        private async Task<Models.OAuth2AccessData> OAuth2GetToken(MPZConfig cfgData)
        {
            Logger.Log("OAuth2 - OAuth2GetToken");

            return await Task.FromResult(await OAuth2.GetElibilityToken(cfgData.OAuth2, cfgData.UserAuthorization));
        }
        private async Task<Models.OAuth2AccessData> OAuth2GetUser(string access_token)
        {
            Logger.Log("OAuth2 - OAuth2GetUser (Search for the user who owns the token)");

            //return await Task.FromResult(await OAuth2.GetElibilityToken(cfgData.OAuth2, cfgData.UserAuthorization));
            return null;
        }
    }
}