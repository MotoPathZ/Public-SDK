using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class EndPoints
    {
        #region Domens
                                                                                                      ////////////////////////////////////////////////////
        private static readonly string MASTER = "127.0.0.1:8000";                                    //       ===> MASTER DOMEN                        //
        //private static readonly string MASTER =  "motopathz.ru";                                  //        ===> MASTER DOMEN                       //
        private static readonly string MPROTOCOL =  "http://";                                     //         ===> MASTER DOMEN                      //
                                                                                                  ////////////////////////////////////////////////////
        public static readonly string OAUTH2  = $"{MPROTOCOL}{MASTER}/api/v1/oauth/";            //           ===> DOMEN FOR AUTH                  //
        public static readonly string API     = $"{MPROTOCOL}{MASTER}/api/{API_VERSION.v01}/";  //            ===> DOMEN FOR API                  //
        public static readonly string CDN     = $"{MPROTOCOL}{MASTER}/cdn/";                   //             ===> DOMEN FOR CDN                 //
                                                                                              ////////////////////////////////////////////////////
        private static readonly string HOST_PORT = "42522";                                  //               ===> PORT FOR MPZ SERVER         //
        public static readonly string HOST    = $"{MPROTOCOL}master.{MASTER}:{HOST_PORT}/"; //                ===> DOMEN FOR MPZ SERVER       //
                                                                                           ////////////////////////////////////////////////////
        #endregion

        #region Main
        public static readonly string OAUTH2_TOKEN = "token/";
        public static readonly string OAUTH2_AUTHORIZE = "authorize/";
        public static readonly string CDN_STATIC_FOLDER = "attachments/";
        public static readonly string CDN_STATIC_CATALOG = $"{CDN_STATIC_FOLDER}/static/";
        #endregion
        #region Systems
        public static readonly string system_112 = "/system-112";
        #endregion
        #region Objects
        public static readonly string user = "user";
        public static readonly string client = "clients";
        //oauth2 user
        private static readonly string oauth_user = "oauth_user";
        public static readonly string oauth2_auth_user = $"{oauth_user}/user";
        #endregion
        #region Communications
        public static readonly string post = "/сommunication/post";
        public static readonly string devlog = "/сommunication/devlog";
        #endregion
        #region Tools
        public static readonly string tools = $"{oauth_user}/tools";
        public static readonly string tools_max_spead = $"{tools}/max_spead";
        #endregion

        #region Other
        private enum API_VERSION { v01,v02,v03,v04,v05,v06,v07,v08,v09,v1 }
        #endregion
    }
}
