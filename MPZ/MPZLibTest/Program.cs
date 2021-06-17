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
            Console.WriteLine("MPZ Lib Test - Start");
            
            MPZClient mpz = new MPZClient();
            //For Create json config
            //CreateConfig();
        }
        #region FOR CREATE JSON CONFIG
        static void CreateConfig()
        {
            new MPZClient(new MPZConfig
            {
                maxTimeForResponce = 10,
                APIVersion = MPZConfig.APIversions.main,
                OAuth2 = new MPZConfig.OAuth2Config
                {
                    grant_type = MPZConfig.OAuth2Config.grantType.password,
                    client_id = "93abd5bb-40a7-4bff-a523-b016a4ea9f9b",
                    client_secret = "CnKxVKPdRovXdv7g5o6dPEhFNBe9jiJaViBCx5U0",
                    scope = "*"
                },
                UserAuthorization = new MPZConfig.UserAuthConfig { username = "owner@motopathz.ru", password = "XWN-rLs-jxj-Wjr" }
            });
        }
        #endregion
    }
}
