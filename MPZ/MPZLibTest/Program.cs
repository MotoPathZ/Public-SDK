using System;
using System.Threading.Tasks;
using MPZ;
using MPZ.Config;
using MPZ.Models;
using MPZ.Services;

namespace MPZLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programm - Start MPZ Lib for testing.");
            //For Create json config
            //CreateConfig();
            MPZClient mpz = new MPZClient();
        }
        #region FOR CREATE JSON CONFIG
        static void CreateConfig()
        {
            Console.WriteLine("Programm - Start Create Config in mpz lib.");
            new MPZClient(new MPZConfig
            {
                maxTimeForResponce = 10,
                APIVersion = MPZConfig.APIversions.main,
                OAuth2 = new MPZConfig.OAuth2Config
                {
                    grant_type = MPZConfig.OAuth2Config.grantType.password,
                    client_id = "93b32386-56e1-4a59-b4e3-548b15fbf26d",
                    client_secret = "E5NkDrCuQ9KppiyEn4KslKMa6UB4qYkzOItE0J8b",
                    scope = "*"
                },
                UserAuthorization = new MPZConfig.UserAuthConfig { username = "owner@motopathz.ru", password = "XWN-rLs-jxj-Wjr" }
            });
        }
        #endregion
    }
}
