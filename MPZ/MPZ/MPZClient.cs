using System;
using System.Collections.Generic;
using MPZ.Config;

namespace MPZ
{
    public class MPZClient
    {
        public static bool isAuth;
        public static MPZConfig config;
        public static Models.MPZAuth auth;
        public MPZClient(MPZConfig configData)
        {
            config = configData;
            Init();
        }
        public MPZClient()
        {
            bool isLoadCfg = Tools.ProcessingLocalConfig.Load();
            if(isLoadCfg) {
                config = Tools.ProcessingLocalConfig.data;
                Init();
            }
            else
            {
                /*...ERROR LOADING CONFIG FILE FOR SDK MPZ...*/
            }
            
        }
        public async void Init()
        {
            #region Aurhorization
            auth = await Tools.Networking.AurhorizationAsync();
            #endregion
        }
    }
}
