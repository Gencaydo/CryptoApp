using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace CryptoClient
{
    public class CallAPIService
    {
        public static string CallAPI(string _apiUrl, object _postobject, string token, Method method)
        {
            try
            {
                var client = new RestClient(_apiUrl);
                var request = new RestRequest();
                var response = new RestResponse();
                request.AddHeader("cache-control", "no-cache");
                if (!string.IsNullOrEmpty(token)) request.AddHeader("authorization", "Bearer " + token);
                request.AddHeader("accept", "application/json; charset=utf-8");

                if (_postobject != null)
                {
                    var body = JsonConvert.SerializeObject(_postobject);
                    request.AddStringBody(body, DataFormat.Json);
                }

                if (method == Method.Post) response =  client.ExecutePost(request);
                else if (method == Method.Get) response =  client.ExecuteGet(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
