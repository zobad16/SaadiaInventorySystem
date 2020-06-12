using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SaadiaInventorySystem.Client.Backend
{
    public class RestClient
    {
        public HttpClient GetClient()
        {
            HttpClient httpClient = new HttpClient(new RestClientHandler());
            httpClient.BaseAddress = new Uri(AppProperties.Url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(AppProperties.SecurityTokenName, AppProperties.SecutiyTokenValue);
            return httpClient;
        }
       
    }
}
