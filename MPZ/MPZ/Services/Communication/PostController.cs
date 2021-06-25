using MPZ.Config;
using MPZ.Models;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPZ.Services.Communication
{
    public class PostController
    {
        public static async Task<List<MPZPost>> IndexAsync()
        {
            MPZClient.Logger.Log("PostController - IndexAsync");

            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.post);
            try
            {
                return JsonConvert.DeserializeObject<List<MPZPost>>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"PostController - IndexAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new List<MPZPost>();
            }
        }
        public static async Task<MPZPost> ShowAsync(string uuid)
        {
            MPZClient.Logger.Log($"PostController - ShowAsync");
            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.post, uuid);

            try
            {
                return JsonConvert.DeserializeObject<MPZPost>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"PostController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZPost();
            }
        }
        public static async Task<MPZPost> UpdateAsync(string uuid, MPZPost updateData)
        {
            MPZClient.Logger.Log($"PostController - ShowAsync");
            string jsonUpdateData = JsonConvert.SerializeObject(updateData);
            string json = await MPZ.Tools.Networking.SendToServerForUpdate(EndPoints.API, EndPoints.post, jsonUpdateData, uuid);

            try
            {
                return JsonConvert.DeserializeObject<MPZPost>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"PostController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZPost();
            }
        }
        public static async Task<MPZPost> DeleteAsync(string uuid)
        {
            MPZClient.Logger.Log($"PostController - DeleteAsync");
            string json = await MPZ.Tools.Networking.SendToServerForDelete(EndPoints.API, EndPoints.post, null, uuid);

            /*try
            {
                //return JsonConvert.DeserializeObject<MPZPost>(json);
            }
            catch (Exception e)
            {
                //MPZClient.Logger.Log($"PostController - DeleteAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                //return new MPZPost();
            }*/
            return new MPZPost();
        }
    }
}
