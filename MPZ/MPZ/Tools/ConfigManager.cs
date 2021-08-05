
using System.IO;
using MPZ.Config;
using Newtonsoft.Json;

namespace MPZ.Tools
{
    public class ConfigManager
    {
        public string pathToConfig { get; set; } = "mpz.config";
        public MPZConfigData data { get; set; }

        public MPZConfigData LoadConfig()
        {
            MPZClient.Logger.Log("Config - LoadConfig");
            MPZClient.Logger.Log("Config - Check if the config file exists");
            if (File.Exists(pathToConfig))
            {
                MPZClient.Logger.Log("Config - File Exists");
                try { 
                data = JsonConvert.DeserializeObject<MPZConfigData>(File.ReadAllText(pathToConfig));
                }
                catch
                {
                    data = GetDefaultData();
                }
            }
            else
            {
                MPZClient.Logger.Log("Config - No File Exists");
                data = GetDefaultData();
            }
            return data;
        }

        private MPZConfigData GetDefaultData()
        {
           return new MPZConfigData()
           {
                authType = MPZConfigData.AuthorizationType.Token,
                oauth2AccessData = new Models.Other.Authorization.OAuth2AccessData(),
                OAuth2AuthorizationData = new MPZConfigData.OAuth2AuthData(),
                tokenData = new Models.Other.Authorization.TokenData(),
                UserAuthorizationData = new MPZConfigData.UserAuthData(),
           };
        }

        public void ConfigSave()
        {
            MPZClient.Logger.Log("Config - ConfigSave");
            if (File.Exists(pathToConfig))
            {
                File.WriteAllText(pathToConfig, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            else 
            {
                File.Create(pathToConfig);
                File.WriteAllText(pathToConfig, JsonConvert.SerializeObject(data, Formatting.Indented));
            }
        }
    }
}
