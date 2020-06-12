using Newtonsoft.Json;
using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Services
{
    public class UserService:RestClient
    {
        
        public async Task<bool> CallAddService(User user)
        {
            using (var client = GetClient())
            {
                var _user = JsonConvert.SerializeObject(user);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/user/signup", _user);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        
        public async Task<User> CallGetService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/user/{id}");
                User data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<User> responseData = result.ReadAsAsync<User>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<User>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/user/users");
                List<User> data = new List<User>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<User>> responseData = result.ReadAsAsync<List<User>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(User user)
        {
            using (var client = GetClient())
            {
                var _user = JsonConvert.SerializeObject(user);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/user/update", user);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallDeleteService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/user/delete", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallAdminDeleteService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/user/admindelete", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }


    }
}
