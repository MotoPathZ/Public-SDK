using MPZ.Config;
using MPZ.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MPZ.Service
{
    public static class News
    {
        static HttpClient client = new HttpClient();
        public static async Task<List<MPZNews>> IndexAsync()
        {
            Console.WriteLine($"Start | MPZ.Service.News | IndexAsync");

            string link = MPZClient.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.News);

            var json = await client.GetStringAsync(link);
            try
            {
                return JsonConvert.DeserializeObject<List<MPZNews>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error | MPZ.Service.News | IndexAsync | Error: {e.Message}");
                return new List<MPZNews>();
            }
        }
        public static async Task<MPZNews> ShowAsync(uint id)
        {
            Console.WriteLine($"Start | MPZ.Service.News | ShowAsync");
            string link = MPZClient.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.News, id.ToString());

            try
            {
                var json = await client.GetStringAsync(link);

                return JsonConvert.DeserializeObject<MPZNews>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error | MPZ.Service.News | ShowAsync | Error: {e.Message}");
                return new MPZNews();
            }
        }
        public static async Task<HttpStatusCode> CreateAsync(MPZNews item)
        {
            string link = MPZClient.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.News, 
                $"?logo={item.logo}&title={item.title}&body={item.body}");

            var stringContent = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync(link, stringContent);
            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> UpdateAsync(MPZNews item)
        {
            string link = MPZClient.GetLink(Endpoints.Servers.API_SERVER, Endpoints.Type.News, 
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
        }
    }
}
