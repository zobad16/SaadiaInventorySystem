using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Services
{
    public class OldPartService: RestClient
    {
        public async Task<bool> CallAddService(OldPart op)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/oldparts/add", op);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<OldPart> CallGetService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/oldparts/{id}");
                OldPart data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<OldPart> responseData = result.ReadAsAsync<OldPart>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<OldPart>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/oldparts/oldparts");
                List<OldPart> data = new List<OldPart>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<OldPart>> responseData = result.ReadAsAsync<List<OldPart>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(OldPart op)
        {
            using (var client = GetClient())
            {
                
                HttpResponseMessage response = await client.PostAsJsonAsync("api/oldparts/update", op);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/oldparts/delete", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/oldparts/admindelete", id);

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
