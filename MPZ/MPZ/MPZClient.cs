using System;
using System.Collections.Generic;
using MPZ.Config;

namespace MPZ
{
    public class MPZClient
    {
        public static string token;
        public MPZClient()
        {
            Init();
        }
        public void Init()
        {
        }
        public static string GetLink(Endpoints.Servers server, Endpoints.Type response, string responceData = null, string action = null)
        {
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
                    link = $"{Endpoints.HostIP}:{Endpoints.HostPort}";
                    break;
                default:
                    link = Endpoints.API_SERVER;
                    break;
            }
            string responcedata = "";

            if (action != null) responcedata = $"/{action}";
            if (responceData != null) responcedata += $"/{responceData}";

            switch (response)
            {
                case Endpoints.Type.News:
                    link += $"/{Endpoints.News}/{responcedata}";
                    break;
                case Endpoints.Type.Devlog:
                    link += $"/{Endpoints.Devlog}/{responcedata}";
                    break;

                case Endpoints.Type.ThisUser:
                    link += $"/{Endpoints.ThisUser}/{responcedata}";
                    break;
                case Endpoints.Type.Client:
                    link += $"/{Endpoints.Client}/{responcedata}";
                    break;

                case Endpoints.Type.System112:
                    link += $"/{Endpoints.System112}/{responcedata}";
                    break;
                default:
                    break;
            }
            return link;
        }
    }
}
