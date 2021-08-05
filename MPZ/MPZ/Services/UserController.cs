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
        public static async Task<MPZUser> ShowOAuth2AuthorizationAsync()
        {
            MPZClient.Logger.Log($"UserController - ShowOAuth2AuthorizationAsync");
            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.auth_user);
            try
            {
                return JsonConvert.DeserializeObject<MPZUser>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"UserController - ShowUserAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZUser();
            }
        }
        public static async Task<MPZUser> ShowByIdAsync(uint user_id)
        {
            MPZClient.Logger.Log($"UserController - ShowUser");
            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.user, user_id.ToString());

            try
            {
                return JsonConvert.DeserializeObject<MPZUser>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"UserController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZUser();
            }
        }
        public static async Task<MPZUser> UpdateOAuth2UserAsync(MPZUser updateData)
        {
            MPZClient.Logger.Log($"UserController - ShowAsync");
            string jsonUpdateData = JsonConvert.SerializeObject(updateData);
            string json = await MPZ.Tools.Networking.SendToServerForUpdate(EndPoints.API, EndPoints.post, jsonUpdateData);

            try
            {
                return JsonConvert.DeserializeObject<MPZUser>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"UserController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZUser();
            }
        }
    }
}
