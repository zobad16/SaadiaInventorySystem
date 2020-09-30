using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Services
{
    public class InquiryService:RestClient
    {
        public async Task<bool> CallAddService(Inquiry inquiry)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/add", inquiry);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }
        public async Task<bool> CallBulkInsert(List<Inquiry> inquirys)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/add/bulk", inquirys);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }
        public async Task<bool> CallBulkUpdate(List<Inquiry> inquirys)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/update/bulk", inquirys);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }

        public async Task<Inquiry> CallGetService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/inquiry/{id}");
                Inquiry data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<Inquiry> responseData = result.ReadAsAsync<Inquiry>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<Inquiry>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/inquiry/inquirys");
                List<Inquiry> data = new List<Inquiry>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Inquiry>> responseData = result.ReadAsAsync<List<Inquiry>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<List<Inquiry>> CallAdminGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/inquiry/inquirys/admin");
                List<Inquiry> data = new List<Inquiry>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Inquiry>> responseData = result.ReadAsAsync<List<Inquiry>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(Inquiry inquiry)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/update", inquiry);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallActivateService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/activate", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallDeleteService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/delete", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallActivateInquiryService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/activate", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallDisableInquiryService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/disable", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallAdminDeleteService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inquiry/delete/admin", id);

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
