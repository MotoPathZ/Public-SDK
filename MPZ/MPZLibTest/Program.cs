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
        static async Task Main(string[] args)
        {
            Console.WriteLine("Programm - Start MPZ Lib for testing.");
            //For Create json config
            CreateConfig();
            MPZClient mpz = new MPZClient();
            MPZClient.Logger.Log("Search for the user who owns the access token");
            var user = await mpz.ShowAuthUser();
            MPZClient.Logger.Log("-----------------------");
            MPZClient.Logger.Log("Auth User Information");
            MPZClient.Logger.Log($"Auth User ID: {user.id}");
            MPZClient.Logger.Log($"Auth User UUID: {user.uuid}");
            MPZClient.Logger.Log($"Auth User Username: {user.username}");
            MPZClient.Logger.Log($"Auth User email: {user.email}");
            MPZClient.Logger.Log($"Auth User Email Verified At: {user.email_verified_at}");
            MPZClient.Logger.Log($"Auth User Last name: {user.lastname}");
            MPZClient.Logger.Log($"Auth User Firt Name: {user.firstname}");
            MPZClient.Logger.Log("End User Information");
            MPZClient.Logger.Log("--------------------");

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
            new MPZClient(new MPZConfigData
            {
                authType = MPZConfigData.AuthorizationType.User,
                UserAuthorizationData = new MPZConfigData.UserAuthData { username = "simakinmaksimka17072005@mail.ru", password = "yLA-LEq-YAb-J57" },
            });
        }
        #endregion
    }
}
