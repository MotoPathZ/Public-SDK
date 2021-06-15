using MPZ.Config;
using MPZ.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPZ.Services
{
    public static class NewsController
    {
        public static async Task<List<MPZNews>> IndexAsync()
        {
            MPZClient.Logger.Log("NewsController - IndexAsync");

            string json = await Tools.Networking.SendToServerForGetAsync(EndPoints.API_SERVER, EndPoints.News);
            try
            {
                return JsonConvert.DeserializeObject<List<MPZNews>>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"NewsController - IndexAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                return new List<MPZNews>();
            }
        }
        public static async Task<MPZNews> ShowAsync(uint id)
        {
            MPZClient.Logger.Log($"NewsController - ShowAsync");
            string json = await Tools.Networking.SendToServerForGetAsync(EndPoints.API_SERVER, EndPoints.News, id.ToString());

            try
            {
                return JsonConvert.DeserializeObject<MPZNews>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"NewsController - ShowAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                return new MPZNews();
            }
        }
    }
}
