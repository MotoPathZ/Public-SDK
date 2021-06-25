
using System.IO;
using MPZ.Config;
using Newtonsoft.Json;

namespace MPZ.Tools
{
    public class Config
    {
        public string pathToConfig { get; set; } = "mpz.config";
        public MPZConfigData data { get; set; }

        public MPZConfigData LoadConfigAndOAuth2()
        {
            MPZClient.Logger.Log("Config - LoadConfigAndOAuth2");
            MPZClient.Logger.Log("Config - Check if the config file exists");
            if (File.Exists(pathToConfig))
            {
                MPZClient.Logger.Log("Config - File Exists");
                try { 
                data = JsonConvert.DeserializeObject<MPZConfigData>(File.ReadAllText(pathToConfig));
                }
                catch
                {
                    data = new MPZConfigData()
                    {
                        accessData = new Models.OAuth2AccessData(),
                        dataConfig = new MPZConfig()
                        {
                            APIVersion = MPZConfig.APIversions.alpha,
                            OAuth2 = new MPZConfig.OAuth2Config(),
                            UserAuthorization = new MPZConfig.UserAuthConfig(),
                            maxTimeForResponce = 10f
                        }
                    };
                }
            }
            else
            {
                MPZClient.Logger.Log("Config - No File Exists");
                data = new MPZConfigData()
                {
                    accessData = new Models.OAuth2AccessData(),
                    dataConfig = new MPZConfig()
                    {
                        APIVersion = MPZConfig.APIversions.alpha,
                        OAuth2 = new MPZConfig.OAuth2Config(),
                        UserAuthorization = new MPZConfig.UserAuthConfig(),
                        maxTimeForResponce = 10f
                    }
                };
            }
            return data;
        }

        public void ConfigAndOAuth2Save()
        {
            MPZClient.Logger.Log("Config - ConfigAndOAuth2Save");
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
