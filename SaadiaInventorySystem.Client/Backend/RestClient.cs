using Newtonsoft.Json;
using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<string> CallLoginService(User user)
        {
            using (var client = GetClient())
            {
               var _user = JsonConvert.SerializeObject(user);

               HttpResponseMessage response = await client.PostAsJsonAsync("api/login", user);
                
                HttpContent result = response.Content;
                Task<string> responseData = result.ReadAsStringAsync();
                string data = responseData.Result;
                
               return await responseData;

            }
        }
        public async Task<User> CallAddUserService(User user) 
        {
            using (var client = GetClient())
            {
                var _user = JsonConvert.SerializeObject(user);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/login", user);

                HttpContent result = response.Content;
                Task<User> responseData = result.ReadAsAsync<User>();
                User data = responseData.Result;

                return await responseData;

            }
        }
    }
}
