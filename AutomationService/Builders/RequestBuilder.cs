using System;
using System.Net.Http;
using System.Text;
using AutomationService.Helpers;

namespace AutomationService.Builders
{
    public class RequestBuilder
    {
        private static HttpRequestMessage _request;

        private static Uri BaseServiceUri { get; set; }

        public RequestBuilder(string url)
        {
            _request = new HttpRequestMessage();
            BaseServiceUri = new Uri(url);
        }

        public RequestBuilder WithUri(string url)
        {
            _request.RequestUri = new Uri(BaseServiceUri.AbsoluteUri + url);
            return this;
        }

        public RequestBuilder WithBody(string requestBody)
        {
            _request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            return this;
        }

        public RequestBuilder WithMethod(HttpMethod method)
        {
            _request.Method = method;
            return this;
        }

        public ApiResponse Execute()
        {
            using (var httpClient = new HttpClient())
            {
                _request.Headers.Referrer = _request.RequestUri;
                var response = httpClient.SendAsync(_request).Result;
                return new ApiResponse(response);
            }
        }
    }
}
