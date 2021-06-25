using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MPZ.Config;
using MPZ.Models.Tools;
using Newtonsoft.Json;

namespace MPZ.Services.Tools
{
    public class TopSpeedController
    {
        //Нужно ... -> доделать TopSpeedController, по возможности, начать подключать SDK к приложению.
        public static async Task<MPZTopSpeed> IndexAsync()
        {
            MPZClient.Logger.Log("TopSpeedController - IndexAsync");

            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.oa_tools_top_speed);
            try
            {
                return JsonConvert.DeserializeObject<MPZTopSpeed>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"TopSpeedController - IndexAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZTopSpeed();
            }
        }
        public static async Task<MPZTopSpeed> ShowAsync(ulong user_id)
        {
            MPZClient.Logger.Log("TopSpeedController - ShowAsync");

            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.top_speed, user_id.ToString());
            try
            {
                return JsonConvert.DeserializeObject<MPZTopSpeed>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"TopSpeedController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZTopSpeed();
            }
        }
        
        public static async Task<MPZTopSpeed> ShowAllAsync(ulong user_id)
        {
            MPZClient.Logger.Log("TopSpeedController - ShowAllAsync");

            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.top_speed_all, user_id.ToString());
            try
            {
                return JsonConvert.DeserializeObject<MPZTopSpeed>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"TopSpeedController - ShowAllAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZTopSpeed();
            }
        }
        public static async Task<MPZTopSpeed> ShowAsync()
        {
            MPZClient.Logger.Log("TopSpeedController - ShowAsync");

            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.oa_tools_top_speed);
            try
            {
                return JsonConvert.DeserializeObject<MPZTopSpeed>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"TopSpeedController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZTopSpeed();
            }
        }
        
        public static async Task<MPZTopSpeed> ShowAllAsync()
        {
            MPZClient.Logger.Log("TopSpeedController - ShowAllAsync");

            string json = await MPZ.Tools.Networking.SendToServerForGet(EndPoints.API, EndPoints.oa_tools_top_speed_all);
            try
            {
                return JsonConvert.DeserializeObject<MPZTopSpeed>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"TopSpeedController - ShowAllAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZTopSpeed();
            }
        }

        public static async Task<MPZTopSpeed> UpdateOrCreateAsync(TopSpeed updateData)
        {
            MPZClient.Logger.Log($"TopSpeedController - UpdateOrCreateAsync");
            string jsonUpdateData = JsonConvert.SerializeObject(updateData);
            string json = await MPZ.Tools.Networking.SendToServerForUpdate(EndPoints.API, EndPoints.oa_tools_top_speed, jsonUpdateData);

            try
            {
                return JsonConvert.DeserializeObject<MPZTopSpeed>(json);
            }
            catch (Exception e)
            {
                MPZClient.Logger.Log($"TopSpeedController - ShowAsync | Error: {e.Message}", MPZ.Tools.Logger.LogType.Errors);
                return new MPZTopSpeed();
            }
        }
    }
}