using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace AutomationService.Helpers
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ContentAsString { get; set; }

        public JToken ContentAsJson => JToken.Parse(ContentAsString);

        public ApiResponse(HttpResponseMessage responseMessage)
        {
            StatusCode = responseMessage.StatusCode;
            ContentAsString = responseMessage.Content.ReadAsStringAsync().Result;
        }

        public T Content<T>()
        {
            try
            {
                return ContentAsJson.ToObject<T>();
            }
            catch (Exception)
            {
                throw new Exception($"Could tor deserialize {ContentAsString}");
            }
        }

        public void EnsureSuccessful()
        {
            if ((int)StatusCode < 200 || (int)StatusCode >= 300)
            {
                throw new Exception(
                    $"StatusCode is {StatusCode}. Expected to be successfull. Content = {ContentAsString}");
            }
        }
    }
}
