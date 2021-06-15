using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MPZ.Config;
using Newtonsoft.Json;

namespace MPZ.Tools
{
    public class Networking
    {
        #region Public method
        public static async System.Threading.Tasks.Task<string> SendToServerForGetAsync(string server, string requestTo, string responce = null, string action = null)
        {
            string url = GetLink(server, requestTo, responce, action);
            return await SendToServerForGetAsync(url);
        }
        public static async System.Threading.Tasks.Task<string> SendToServerForPost(string server, string requestTo, string postData=null, string responce = null,  string action = null)
        {
            string url = GetLink(server, requestTo, responce, action);
            return await SendToServerForPostAsync(url, postData);
        }
        public static async System.Threading.Tasks.Task<string> SendToServerForUpdate(string server, string requestTo, string postData=null, string responce = null,  string action = null)
        {
            string url = GetLink(server, requestTo, responce, action);
            return await SendToServerForUpdateAsync(url, postData);
        }
        public static async System.Threading.Tasks.Task<string> SendToServerForDelete(string server, string requestTo, string postData=null, string responce = null,  string action = null)
        {
            string url = GetLink(server, requestTo, responce, action);
            return await SendToServerForDeleteAsync(url, postData);
        }
        #endregion
        private static string GetLink(string server, string requestTo, string responce = null, string action = null)
        {
            string link = server;
            #region Get Recponce Data
            string responceData = "";
            if (action != null) responceData = $"/{action}";
            if (responce != null) responceData += $"/{responce}";
            link += requestTo;
            #endregion
            return link;
        }

        #region Async
        private static async System.Threading.Tasks.Task<string> SendToServerForGetAsync(string url)
        {
            MPZClient.Logger.Log("Network - SendToServerForGetAsync");
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", MPZClient.config.data.accessData.AccessToken);

                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        Content = new StringContent("", Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(url),
                    };

                    var jsonContent = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();

                    return jsonContent;
                }
            }
        }
        private static async System.Threading.Tasks.Task<string> SendToServerForPostAsync(string url, string postData = null)
        {
            MPZClient.Logger.Log("Network - SendToServerForPostAsync");
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", MPZClient.config.data.accessData.AccessToken);
                    
                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        Content = new StringContent(postData, Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(url),
                    };

                    var jsonContent = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
                    return jsonContent;
                }
            }
        }
        private static async System.Threading.Tasks.Task<string> SendToServerForUpdateAsync(string url, string postData = null)
        {
            MPZClient.Logger.Log("Network - SendToServerForPostAsync");
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", MPZClient.config.data.accessData.AccessToken);

                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Put,
                        Content = new StringContent(postData, Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(url),
                    };

                    var jsonContent = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();

                    return jsonContent;
                }
            }
        }
        private static async System.Threading.Tasks.Task<string> SendToServerForDeleteAsync(string url, string postData = null)
        {
            MPZClient.Logger.Log("Network - SendToServerForPostAsync");
            using (HttpClientHandler httpClientHandler = new HttpClientHandler())
            {
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", MPZClient.config.data.accessData.AccessToken);

                    var requestMessage = new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        Content = new StringContent(postData, Encoding.UTF8, "application/json"),
                        RequestUri = new Uri(url),
                    };

                    var jsonContent = await client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();

                    return jsonContent;
                }
            }
        }
        #endregion
    }
}