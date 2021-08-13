using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPZ.Services.Auth
{
    public static class Tools
    {
        public static bool CheckingLifeTokenUseDate(DateTime expires_at)
        {
            MPZClient.Logger.Log("CheckingLifeTokenUseDate");
            if (expires_at < DateTime.Now.AddMinutes(2))
            {
                return true;
            }
            return false;
        }
        #region CheckingIsNull
        public static bool CheckingIsNull(string item)
        {
            if (item == null && item == "")
            {
                MPZClient.Logger.Log("CheckingIsNull (string) - true");
                return true;
            }
            MPZClient.Logger.Log("CheckingIsNull (string) - false");
            return false;
        }
        public static bool CheckingIsNull(object item)
        {
            if (item == null)
            {
                MPZClient.Logger.Log("CheckingIsNull (object) - true");
                return true;
            }
            MPZClient.Logger.Log("CheckingIsNull (object) - false");
            return false;
        }
        #endregion
    }
}
