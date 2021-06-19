using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MPZ.Config;
using MPZ.Models;
using Newtonsoft.Json;

namespace MPZ.Services
{
    public class UserController
    {
        public static async Task<MPZUser> ShowAuthorizationAsync(string uuid)
        {
            return await ShowAsync(uuid);
        }
        public static async Task<MPZUser> ShowAsync(string uuid)
        {
            MPZClient.Logger.Log($"UserController - ShowUser");
            string json = await Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.user, uuid);

            try
            {
                return JsonConvert.DeserializeObject<MPZUser>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"UserController - ShowUserAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                return new MPZUser();
            }
        }
        public static async Task<MPZUser> UpdateAsync(string uuid, MPZUser updateData)
        {
            MPZClient.Logger.Log($"UserController - ShowAsync");
            string jsonUpdateData = JsonConvert.SerializeObject(updateData);
            string json = await Tools.Networking.SendToServerForUpdate(EndPoints.API, EndPoints.post, jsonUpdateData, uuid);

            try
            {
                return JsonConvert.DeserializeObject<MPZUser>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"UserController - ShowAsync | Error: {e.Message}", Tools.Logger.LogType.Errors);
                return new MPZUser();
            }
        }
    }
}
