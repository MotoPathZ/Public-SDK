using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class Endpoints
    {
        public static readonly string API_SERVER = "http://127.0.0.1:8000/api/";
        public static readonly string CDN_SERVER = "http://127.0.0.1:8000/cdn/";
        public static readonly string CDN_STATIC_FOLDER = "files/";
        public static readonly string CDN_STATIC_CATALOG = $"{CDN_STATIC_FOLDER}/static/";
        public static readonly string HostIP = "127.0.0.1";
        public static readonly string HostPort = "53564";

        #region Other
        public static string News = "/news";
        public static string Devlog = "/devlog";
        #endregion
        #region Objects
        public static string ThisUser = "/user";
        public static string Client = "/clients";
        #endregion
        #region Systems
        public static string System112 = "/system-112";
        #endregion
        public enum Servers {
            API_SERVER, CDN_SERVER, Host
        }
        public enum Type {
            //CDN_STATIC_FOLDER, CDN_STATIC_CATALOG,
            News, Devlog,
            ThisUser,Client,
            System112,
        }
    }
}
