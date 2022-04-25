using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SimpleWarehouseWcfService.Helpers
{
    internal class RestHelper
    {
        private static string _token;
        private static readonly RestClient Client;

        static RestHelper()
        {
            Client = new RestClient("http://localhost:63803");
            Task.Run(async () => { await SetToken(); });
        }

        private static async Task SetToken()
        {
            _token = await Post<string>("api/token/post", new { UserName = "Test", Password = "123" });
        }

        internal static async Task<List<T>> Get<T>(string url, List<KeyValuePair<string, object>> paramList = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);
            request.AddHeader("Authorization", $"Bearer {_token}");
            paramList?.ForEach(q => request.AddParameter(q.Key, q.Value));
            var response = await Client.ExecuteAsync(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Response<T>>(response.Content).Data;
                case HttpStatusCode.Unauthorized:
                    await SetToken();
                    return await Get<T>(url, paramList);
                case 0:
                    throw new Exception(response.ErrorMessage);
                default:
                    throw new Exception(response.StatusDescription);
            }
        }

        internal static async Task<T> Post<T>(string url, object data)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddHeader("Authorization", $"Bearer {_token}");
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            var response = await Client.ExecuteAsync(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<T>(response.Content);
                case HttpStatusCode.Unauthorized:
                    if (url == "api/token/post") goto case default;
                    await SetToken();
                    return await Post<T>(url, data);
                case 0:
                    throw new Exception(response.ErrorMessage);
                default:
                    throw new Exception(response.StatusDescription);
            }
        }

        internal static async Task<List<T>> PostList<T>(string url, object data)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddHeader("Authorization", $"Bearer {_token}");
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            var response = await Client.ExecuteAsync(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Response<T>>(response.Content).Data;
                case HttpStatusCode.Unauthorized:
                    if (url == "api/token/post") goto case default;
                    await SetToken();
                    return await PostList<T>(url, data);
                case 0:
                    throw new Exception(response.ErrorMessage);
                default:
                    throw new Exception(response.StatusDescription);
            }
        }

        internal static async Task<T> Put<T>(string url, object data)
        {
            var request = new RestRequest(url, Method.PUT, DataFormat.Json);
            request.AddHeader("Authorization", $"Bearer {_token}");
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            var response = await Client.ExecuteAsync(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Response<T>>(response.Content).Data[0];
                case HttpStatusCode.Unauthorized:
                    await SetToken();
                    return await Put<T>(url, data);
                case 0:
                    throw new Exception(response.ErrorMessage);
                default:
                    throw new Exception(response.StatusDescription);
            }
        }

        internal static async Task<bool> Delete(string url, List<KeyValuePair<string, object>> parameters = null)
        {
            var request = new RestRequest(url, Method.DELETE, DataFormat.Json);
            request.AddHeader("Authorization", $"Bearer {_token}");
            parameters?.ForEach(q => request.AddParameter(q.Key, q.Value));
            var response = await Client.ExecuteAsync(request);
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<Response<object>>(response.Content).Status == "Success";
                case HttpStatusCode.Unauthorized:
                    await SetToken();
                    return await Delete(url, parameters);
                case 0:
                    throw new Exception(response.ErrorMessage);
                default:
                    throw new Exception(response.StatusDescription);
            }
        }
    }

    internal class Response<T>
    {
        public string Status { get; set; }
        public string Model { get; set; }
        public string Message { get; set; }
        public string SpecialMessage { get; set; }
        public List<T> Data { get; set; }
    }
}