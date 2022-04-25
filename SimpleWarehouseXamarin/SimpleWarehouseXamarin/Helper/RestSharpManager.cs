using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace SimpleWarehouseMobil.Helpers
{
    internal class RestSharpManager
    {
        private static string ServerIp; //constants
        protected static RestClient Client;
        protected static object LockSync = new object();
        public static void Init(string baseUrl)
        {
            lock (LockSync)
            {
                if (Client != null) return;
                ServerIp = baseUrl;
                Client = new RestClient(ServerIp);
                //var req = new RestRequest("values/Init", Method.GET);
                //Client.Execute(req);
                //var statu = Client.Execute<Dictionary<string, object>>(req);
                //var value = statu.Data.FirstOrDefault(p => p.Key == "Result").Value.ToString();
            }
        }
        public static async Task<List<TResponse>> RestSharpGet<TResponse>(string url, string token, List<KeyValuePair<string, object>> paramList = null)
        {
            try
            {
                var req = new RestRequest(url, Method.GET);
                req.AddHeader("Authorization", string.Format("Bearer {0}", token));
                if (paramList != null)
                    paramList.ForEach(q => req.AddParameter(q.Key, q.Value));
                //req.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                var response = await Client.ExecuteAsync(req);
                var responseMessage = JsonConvert.DeserializeObject<ResponseMessage<TResponse>>(response.Content);
                return responseMessage.Data;
            }
            catch (Exception e)
            {
                return new List<TResponse>();
            }

        }
        public static async Task<TResponse> RestSharpPost<TResponse>(string url, object data, string token)
        {
            var jsonToSend = JsonConvert.SerializeObject(data);
            var req = new RestRequest(url, Method.POST);
            req.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);


            req.AddHeader("Authorization", string.Format("Bearer {0}", token));
            req.RequestFormat = DataFormat.Json;
            var response = await Client.ExecuteAsync(req);
            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<TResponse>(response.Content);
            if (response.StatusCode == 0)
                throw new Exception(response?.ErrorMessage);
            if(response.StatusCode==HttpStatusCode.Unauthorized)
                throw new Exception("Yetkisiz Giriş Bilgilerinizi Kontrol Ediniz...");

            throw new Exception(response?.StatusDescription);


        }

        public static async Task<bool> RestSharpDelete(string url, string token, List<KeyValuePair<string, object>> parameters = null)
        {
            var req = new RestRequest(url, Method.DELETE);
            req.AddHeader("Authorization", string.Format("Bearer {0}", token));
            if (parameters != null)
                parameters.ForEach(q => req.AddParameter(q.Key, q.Value));
            //req.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await Client.ExecuteAsync(req);
            var responseMessage = JsonConvert.DeserializeObject<ResponseMessage<object>>(response.Content);
            return responseMessage.Status == "success";
        }

        public static async Task<TResponse> RestSharpPut<TResponse>(string url, object data, string token)
        {
            var jsonToSend = JsonConvert.SerializeObject(data);
            var req = new RestRequest(url, Method.PUT);
            req.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);


            req.AddHeader("Authorization", string.Format("Bearer {0}", token));
            req.RequestFormat = DataFormat.Json;
            var response = await Client.ExecuteAsync(req);
            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ResponseMessage<TResponse>>(response.Content).Data[0];
            throw new Exception(response.StatusDescription);
        }
    }
}