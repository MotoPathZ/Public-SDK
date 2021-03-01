using MPZ.Config;
using MPZ.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPZ.Service.Personal
{
    public static class DevlogController
    {
        static HttpClient client = new HttpClient();
        public static async Task<List<Models.Personal.MPZDevlog>> IndexAsync()
        {
            Console.WriteLine($"Start | MPZ.Service.Personal.DevlogController | IndexAsync");

            string link = Tools.Networking.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.Devlog);

            var json = await client.GetStringAsync(link);
            try
            {
                return JsonConvert.DeserializeObject<List<Models.Personal.MPZDevlog>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error | MPZ.Service.Personal.DevlogController | IndexAsync | Error: {e.Message}");
                return new List<Models.Personal.MPZDevlog>();
            }
        }
        public static async Task<Models.Personal.MPZDevlog> ShowAsync(uint id)
        {
            Console.WriteLine($"Start | MPZ.Service.Personal.DevlogController | ShowAsync");
            string link = Tools.Networking.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.Devlog, id.ToString());

            try
            {
                var json = await client.GetStringAsync(link);

                return JsonConvert.DeserializeObject<Models.Personal.MPZDevlog>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error | MPZ.Service.Personal.DevlogController | ShowAsync | Error: {e.Message}");
                return new Models.Personal.MPZDevlog();
            }
        }/*
        public static async Task<HttpStatusCode> CreateAsync(MPZNews item)
        {
            string link = Tools.Networking.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.Devlog, 
                $"?logo={item.logo}&title={item.title}&body={item.body}");

            var stringContent = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync(link, stringContent);
            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> UpdateAsync(MPZNews item)
        {
            string link = Tools.Networking.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.Devlog, 
                $"/{item.id}/&logo={item.logo}&title={item.title}&body={item.body}");

            var stringContent = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PutAsync(link, stringContent);
            return response.StatusCode;
        }
        static async Task<HttpStatusCode> DeleteAsync(uint id)
        {
            string link = $"{Endpoints.API_SERVER}{Endpoints.News}/{id}";
            HttpResponseMessage response = await client.DeleteAsync(link);
            return response.StatusCode;
        }*/
    }
}
