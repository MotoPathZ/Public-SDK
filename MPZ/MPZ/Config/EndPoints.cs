using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class EndPoints
    {
        #region Domens
                                                                                                      ////////////////////////////////////////////////////
        private static readonly string MASTER    = "127.0.0.1:8000";                                 //       ===> MASTER DOMEN                        //
        //private static readonly string MASTER =  "motopathz.ru";                                  //        ===> MASTER DOMEN                       //
        public static readonly string OAUTH2  = $"http://{MASTER}/api/v1/oauth/";                  //           ===> DOMEN FOR AUTH                  //
        public static readonly string API     = $"http://{MASTER}/api/{API_VERSION.v1}/";         //            ===> DOMEN FOR API                  //
        public static readonly string CDN     = $"http://{MASTER}/cdn/";                         //             ===> DOMEN FOR CDN                 //
                                                                                                ////////////////////////////////////////////////////
        public static readonly string  HOST   = $"http://master.{MASTER}:12345/";              //                ===> DOMEN FOR MPZ SERVER       //
                                                                                              ////////////////////////////////////////////////////
        #endregion

        #region Main
        public static readonly string OAUTH2_TOKEN = "token/";
        public static readonly string OAUTH2_AUTHORIZE = "authorize/";
        public static readonly string CDN_STATIC_FOLDER = "attachments/";
        public static readonly string CDN_STATIC_CATALOG = $"attachments/static/";
        #endregion
        #region Systems
        public static readonly string system_112 = "/system-112";
        #endregion
        #region Objects
        public static readonly string user = "user";
        public static readonly string client = "clients";
        #endregion
        #region Communications
        public static readonly string post = "/сommunication/post";
        public static readonly string devlog = "/сommunication/devlog";
        #endregion
        #region Tools
        public static readonly string tools = $"tools";
        public static readonly string top_speed = $"tools/top_speed";
        public static readonly string top_speed_all = $"tools/top_speed/all";
        #endregion
        #region OAuth2 Auth User
        //oauth2 user
        //private static readonly string oauth_user = "oauth_user";
        /* Prefix oa = oauth2 user authorization */
        public static readonly string oa_user = $"oauth_user/user";
        public static readonly string oa_auth_tools = $"oauth_user/tools";
        public static readonly string oa_tools_top_speed = $"oauth_user/top_speed";
        public static readonly string oa_tools_top_speed_all = $"oauth_user/all_top_speed";
        #endregion

        #region Other
        //For API
        private enum API_VERSION { v01,v02,v03,v04,v05,v06,v07,v08,v09,v1 }
        #endregion
    }
}
