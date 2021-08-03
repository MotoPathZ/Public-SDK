using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Config
{
    public class EndPoints
    {
        #region Domens
                                                                                                      ////////////////////////////////////////////////////
        public static readonly string OAUTH2  = $"http://127.0.0.1:8000/api/v1/oauth/";              //         ===> DOMEN FOR AUTH            //////////
        public static readonly string API     = $"http://127.0.0.1:8000/api/";                      //          ===> DOMEN FOR API            //////////
        public static readonly string CDN     = $"http://127.0.0.1:8000/cdn/";                     //           ===> DOMEN FOR CDN           //////////
                                                                                                  ////////////////////////////////////////////////////
        #endregion

        #region Main
        public static readonly string OAUTH2_TOKEN = "token/";
        public static readonly string OAUTH2_AUTHORIZE = "authorize/";
        public static readonly string API_GET_TOKEN = "api/authorize/use/user";
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
        public static readonly string post = "сommunication/post";
        public static readonly string devlog = "сommunication/devlog";
        #endregion
        #region Tools
        public static readonly string tools = $"tools";
        public static readonly string top_speed = $"tools/top_speed";
        public static readonly string top_speed_all = $"tools/top_speed/all";
        #endregion
        #region Auth User
        //auth user
        //private static readonly string auth_user = "auth_user";
        public static readonly string auth_user = $"@me";
        public static readonly string auth_tools = $"me/tools";
        public static readonly string auth_tools_top_speed = $"me/@top_speed";
        public static readonly string auth_tools_top_speed_all = $"me/@top_speed/all";
        #endregion
    }
}
