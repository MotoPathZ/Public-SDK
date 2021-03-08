using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class Endpoints
    {
        public static readonly string API_SERVER = "http://127.0.0.1:8000/api";
        //public static readonly string API_SERVER = "https://api.motopathz.ru";
        public static readonly string CDN_SERVER = "http://127.0.0.1:8000/cdn/";
        //public static readonly string CDN_SERVER = "https://cdn.motopathz.ru/";
        public static readonly string CDN_STATIC_FOLDER = "files/";
        public static readonly string CDN_STATIC_CATALOG = $"{CDN_STATIC_FOLDER}/static/";
        public static readonly string HostIP = "127.0.0.1";
        public static readonly string HostPort = "53564";

        #region Main
        public static readonly string Authorization = "/auth";
        #endregion
        #region Systems
        public static readonly string System112 = "/system-112";
        #endregion
        #region Objects
        public static readonly string ThisUser = "/user";
        public static readonly string Client = "/clients";
        #endregion
        #region Communication
        public static readonly string News = "/сommunication/news";
        public static readonly string Devlog = "/сommunication/devlog";
        #endregion
       
        public enum Servers {
            API_SERVER, CDN_SERVER, Host
        }
        public enum Type {
            Authorization,
            //CDN_STATIC_FOLDER, CDN_STATIC_CATALOG,
            News, Devlog,
            ThisUser,Client,
            System112,
        }
    }
}
