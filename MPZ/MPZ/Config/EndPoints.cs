using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class EndPoints
    {
        #region Domens
        /*ORIGINAL DOMENS*/
        public static readonly string OATH2_SERVER = "http://motopathz.ru/api/v1/oauth/";  //SERVER FOR AUTH//
        public static readonly string API_SERVER   = "http://motopathz.ru/api/";          //SERVER FOR API //
        public static readonly string CDN_SERVER   = "http://motopathz.ru/cdn";          //SERVER FOR CDN //
        //END ORIGINAL DOMENS
        //HOST SERVER
        public static readonly string HOST_IP      = "https://server.motopathz.ru/";
        public static readonly string HOST_PORT     = "42522";
        public static readonly string HOST_PASSWORD = "MPZ_250CC-MOTO_43FDB-SN2JZ";
        //END HOST SERVER
        #endregion
        public static readonly string OATH2_TOKEN = "token/";
        public static readonly string OATH2_AUTHORIZE = "authorize/";
        public static readonly string CDN_STATIC_FOLDER = "attachments/";
        public static readonly string CDN_STATIC_CATALOG = $"{CDN_STATIC_FOLDER}/static/";

        #region Main
        //public static readonly string Authorization = "/auth";
        //public static readonly string OAuth2 = "/auth";
        #endregion
        #region Systems
        public static readonly string system_112 = "/system-112";
        #endregion
        #region Objects
        public static readonly string user = "/user";
        public static readonly string client = "/clients";
        #endregion
        #region Communication
        public static readonly string post = "/сommunication/post";
        public static readonly string devlog = "/сommunication/devlog";
        #endregion
    }
}
