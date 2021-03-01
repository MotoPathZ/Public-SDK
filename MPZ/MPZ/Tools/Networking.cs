using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MPZ.Config;
using Newtonsoft.Json;

namespace MPZ.Tools
{
    public class Networking
    {
        public static string GetLink(Endpoints.Servers server, Endpoints.Type response, string responce = null, string action = null)
        {
            #region Get Host
            string link;
            switch (server)
            {
                case Endpoints.Servers.API_SERVER:
                    link = Endpoints.API_SERVER;
                    break;
                case Endpoints.Servers.CDN_SERVER:
                    link = Endpoints.CDN_SERVER;
                    break;
                case Endpoints.Servers.Host:
                    link = $"{Endpoints.HostIP}:{Endpoints.HostPort}/";
                    break;
                default:
                    link = Endpoints.API_SERVER;
                    break;
            }
            #endregion
            #region Get Recponce Data
            string responceData = "";
            if (action != null) responceData = $"/{action}";
            if (responce != null) responceData += $"/{responce}";

            if(MPZClient.isAuth)
            {
                if (responceData == null) responceData = $"?token={MPZ.MPZClient.auth.access_token}";
                else responceData += $"&token={MPZ.MPZClient.auth.access_token}";
            }
            

            switch (response)
            {
                case Endpoints.Type.Authorization:
                    link += $"{Endpoints.Authorization}/{responceData}";
                    break;
                case Endpoints.Type.News:
                    link += $"{Endpoints.News}/{responceData}";
                    break;
                case Endpoints.Type.Devlog:
                    link += $"{Endpoints.Devlog}/{responceData}";
                    break;
                case Endpoints.Type.ThisUser:
                    link += $"{Endpoints.ThisUser}/{responceData}";
                    break;
                case Endpoints.Type.Client:
                    link += $"{Endpoints.Client}/{responceData}";
                    break;
                case Endpoints.Type.System112:
                    link += $"{Endpoints.System112}/{responceData}";
                    break;
                default:
                    break;
            }
            #endregion
            return link;
        }

        public static async System.Threading.Tasks.Task<Models.MPZAuth> AurhorizationAsync()
        {
            #region Create Requst string for Aurhorization
            string requstForAuth = "";
            switch (MPZClient.config.authorizationType)
            {
                case MPZConfig.AuthType.Application:
                    //config.ApplicationAuthorizationConfig;
                    break;
                case MPZConfig.AuthType.Guide:
                    //config.GuideAuthorizationConfig;
                    break;
                case MPZConfig.AuthType.User:
                    requstForAuth = $"?{MPZClient.config.UserAuthorizationConfig.username}&password{MPZClient.config.UserAuthorizationConfig.password}";
                    break;
                case MPZConfig.AuthType.Password:
                    //config.PasswordAuthorizationConfig;
                    break;
                default:
                    break;
            }
            #endregion

            #region Create link for Authorization
            string linkForGetGrant = Tools.Networking.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.Authorization, requstForAuth, "auth");
            #endregion

            #region Get Grant
            HttpClient client = new HttpClient();

            var json = await client.GetStringAsync(linkForGetGrant);
            try
            {
                return JsonConvert.DeserializeObject<Models.MPZAuth>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error | MPZ.Tools.Networking | AurhorizationAsync | Error: {e.Message}");
                return new Models.MPZAuth();
            }
            #endregion
        }
    }
}
