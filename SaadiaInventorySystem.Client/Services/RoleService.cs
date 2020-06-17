using Newtonsoft.Json;
using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Services
{
    public class RoleService :RestClient
    {
        public async Task<bool> CallAddService(Role role)
        {
            using (var client = GetClient())
            {
                var _role = JsonConvert.SerializeObject(role);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/roles/create", _role);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }

        public async Task<Role> CallGetService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/roles/{id}");
                Role data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<Role> responseData = result.ReadAsAsync<Role>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<Role>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/roles/roles");
                List<Role> data = new List<Role>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Role>> responseData = result.ReadAsAsync<List<Role>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(Role role)
        {
            using (var client = GetClient())
            {
                var _user = JsonConvert.SerializeObject(role);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/roles/update", role);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/roles/delete", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/roles/admindelete", id);

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
