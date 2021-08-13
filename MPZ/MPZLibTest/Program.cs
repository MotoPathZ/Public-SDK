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
            MPZClient Client = new MPZClient();

            var user = Client.ShowAuthUser();
            MPZClient.Logger.Debug("-----------------------");
            MPZClient.Logger.Debug("Auth User Information");
            MPZClient.Logger.Debug($"Auth User ID: {user.id}");
            MPZClient.Logger.Debug($"Auth User UUID: {user.uuid}");
            /*MPZClient.Logger.Debug($"Auth User Username: {user.username}");
            MPZClient.Logger.Debug($"Auth User email: {user.email}");
            MPZClient.Logger.Debug($"Auth User Email Verified At: {user.email_verified_at}");
            MPZClient.Logger.Debug($"Auth User Last name: {user.lastname}");
            MPZClient.Logger.Debug($"Auth User Firt Name: {user.firstname}");
            MPZClient.Logger.Debug("End User Information");
            MPZClient.Logger.Debug("--------------------");

            MPZClient.Logger.Debug("Find a user by id to check their personal condition");
            MPZUser myUser = Client.GetUserByID(2).Result;

            MPZClient.Logger.Debug("------------------");
            MPZClient.Logger.Debug("User 2 Information");

            MPZClient.Logger.Debug($"User ID: {myUser.id}");
            MPZClient.Logger.Debug($"User UUID: {myUser.uuid}");
            MPZClient.Logger.Debug($"User Username: {myUser.username}");

            MPZClient.Logger.Debug($"User Last name: {myUser.lastname}");
            MPZClient.Logger.Debug($"User Firt Name: {myUser.firstname}");

            MPZClient.Logger.Log($"User email: {myUser.email}");
            MPZClient.Logger.Log($"User phone: {myUser.phone}");

            MPZClient.Logger.Debug($"User email verified at: {myUser.email_verified_at}");
            MPZClient.Logger.Debug($"User phone verified at: {myUser.phone_verified_at}");

            MPZClient.Logger.Debug($"User status: {myUser.status}");
            MPZClient.Logger.Debug($"User system (if system): {myUser.system}");
            MPZClient.Logger.Debug($"User settings: {myUser.settings}");

            MPZClient.Logger.Debug($"User locale: {myUser.locale}");
            MPZClient.Logger.Debug($"User mfa: {myUser.mfa}");
            MPZClient.Logger.Debug($"User flags: {myUser.flags}");
            MPZClient.Logger.Debug($"User web site: {myUser.web_site}");
            MPZClient.Logger.Debug("End User 2 Information");
            MPZClient.Logger.Debug("----------------------");*/
        }
        #region FOR CREATE JSON CONFIG
        static void CreateConfig()
        {
            Console.WriteLine("Programm - Start Create Config in mpz lib.");
            new MPZClient(new MPZConfigData
            {
                authType = MPZConfigData.AuthorizationType.User,
                UserAuthorizationData = new MPZConfigData.UserAuthData { username = "owner@motopathz.ru", password = "58L-Q5R-ZpC-LTX" },
            });
        }
        #endregion
    }
}
