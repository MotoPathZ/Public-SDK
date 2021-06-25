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


            MPZClient.Logger.Log("Find a user by id to check their personal condition");
            MPZUser myUser = mpz.GetUserByID(2).Result;

            MPZClient.Logger.Log("------------------");
            MPZClient.Logger.Log("User 2 Information");

            MPZClient.Logger.Log($"User ID: {myUser.id}");
            MPZClient.Logger.Log($"User UUID: {myUser.uuid}");
            MPZClient.Logger.Log($"User Username: {myUser.username}");

            MPZClient.Logger.Log($"User Last name: {myUser.lastname}");
            MPZClient.Logger.Log($"User Firt Name: {myUser.firstname}");

            MPZClient.Logger.Log($"User email: {myUser.email}");
            MPZClient.Logger.Log($"User phone: {myUser.phone}");

            MPZClient.Logger.Log($"User email verified at: {myUser.email_verified_at}");
            MPZClient.Logger.Log($"User phone verified at: {myUser.phone_verified_at}");

            MPZClient.Logger.Log($"User status: {myUser.status}");
            MPZClient.Logger.Log($"User system (if system): {myUser.system}");
            MPZClient.Logger.Log($"User settings: {myUser.settings}");

            MPZClient.Logger.Log($"User locale: {myUser.locale}");
            MPZClient.Logger.Log($"User mfa: {myUser.mfa}");
            MPZClient.Logger.Log($"User flags: {myUser.flags}");
            MPZClient.Logger.Log($"User web site: {myUser.web_site}");
            MPZClient.Logger.Log("End User 2 Information");
            MPZClient.Logger.Log("----------------------");
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
