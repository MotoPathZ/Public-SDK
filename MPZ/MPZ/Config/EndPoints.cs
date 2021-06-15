using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class EndPoints
    {
        #region Domens
        /*ORIGINAL DOMENS AND HOST*//*
        public static readonly string OATH2_SERVER = "https://oauth.motopathz.ru";  //SERVER FOR AUTH//
        public static readonly string API_SERVER   = "https://api.motopathz.ru/";  //SERVER FOR API //
        public static readonly string CDN_SERVER   = "https://cdn.motopathz.ru/"; //SERVER FOR CDN //

        //HOST SERVER
        public static readonly string HOST_IP      = "https://server.motopathz.ru/";
        public static readonly string HOST_PORT     = "42522";
        public static readonly string HOST_PASSWORD = "MPZ_250CC-MOTO_43FDB-SN2JZ";
        //END HOST SERVER

        //END ORIGINAL DOMENS AND HOST*/
        //DOMENS AND HOST FOR LOCAL TEST (FOR DEVELOPER`S MPZ)
        public static readonly string OATH2_SERVER = "http://127.0.0.1:8000/oauth/"; //SERVER FOR AUTH//
        public static readonly string API_SERVER   = "http://127.0.0.1:8000/api/";  //SERVER FOR API //
        public static readonly string CDN_SERVER   = "http://127.0.0.1:8000/cdn/"; //SERVER FOR CDN //

        //HOST SERVER
        public static readonly string HOST_IP = "127.0.0.1";
        public static readonly string HOST_PORT = "42522";
        public static readonly string HOST_PASSWORD = "MPZ_250CC-MOTO_43FDB-SN2JZ";
        //END HOST SERVER

        //END DOMENS AND HOST FOR LOCAL TEST (FOR DEVELOPER`S MPZ)
        #endregion
        public static readonly string OATH2_TOKEN = "token/";
        public static readonly string OATH2_AUTHORIZE = "authorize/";
        public static readonly string CDN_STATIC_FOLDER = "files/";
        public static readonly string CDN_STATIC_CATALOG = $"{CDN_STATIC_FOLDER}/static/";

        #region Main
        //public static readonly string Authorization = "/auth";
        //public static readonly string OAuth2 = "/auth";
        #endregion
        #region Systems
        public static readonly string System112 = "/system-112";
        #endregion
        #region Objects
        public static readonly string User = "/user";
        public static readonly string Client = "/clients";
        #endregion
        #region Communication
        public static readonly string News = "/сommunication/news";
        public static readonly string Devlog = "/сommunication/devlog";
        #endregion
    }
}
