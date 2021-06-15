using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MPZ.Config;
using MPZ.Models;

namespace MPZ.Services.Personal
{
    public static class DevlogController
    {
        public static async Task<List<Models.Personal.MPZDevlog>> IndexAsync()
        {
            MPZClient.Logger.Log($"DevlogController - IndexAsync");

            string json = await Tools.Networking.SendToServerForGetAsync(EndPoints.API_SERVER, EndPoints.Devlog);

            try
            {
                return JsonConvert.DeserializeObject<List<Models.Personal.MPZDevlog>>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"DevlogController - IndexAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                return new List<Models.Personal.MPZDevlog>();
            }
        }
        public static async Task<Models.Personal.MPZDevlog> ShowAsync(uint id)
        {
            MPZClient.Logger.Log($"DevlogController - ShowAsync");
            string json = await Tools.Networking.SendToServerForGetAsync(EndPoints.API_SERVER, EndPoints.Devlog, id.ToString());

            try
            {
                return JsonConvert.DeserializeObject<Models.Personal.MPZDevlog>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"DevlogController - ShowAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                return new Models.Personal.MPZDevlog();
            }
        }
    }
}
