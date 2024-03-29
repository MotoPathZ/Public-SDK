﻿using MPZ.Models.Other.Authorization;
using MPZ.Config;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPZ.Services.Auth
{
    public class UserToken
    {
        public static async Task<TokenData> GetElibilityToken(
               MPZConfigData.UserAuthData userAuthData
           )
        {
            MPZClient.Logger.Log("API Token  - GetElibilityToken");

            var from = userAuthData;
            string fromJson = JsonConvert.SerializeObject(from);
            var jsonContent = MPZ.Tools.Networking.SendToServerForPost(EndPoints.API, EndPoints.GET_TOKEN_USE_USER, fromJson).Result;
            MPZClient.Logger.Log("API Token - Access Token Received!");
            MPZClient.Logger.Log(jsonContent);
            TokenData _TokenData = JsonConvert.DeserializeObject<TokenData>(jsonContent);
            return _TokenData;
        }
    }
}
