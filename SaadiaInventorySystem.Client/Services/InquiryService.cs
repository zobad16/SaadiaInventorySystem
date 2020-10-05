using Newtonsoft.Json;
using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Util;
using System;
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

        internal Task CallGetService(object id)
        {
            throw new NotImplementedException();
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
                HttpResponseMessage response = await client.GetAsync("api/inquiry/inquiry");
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
            List<Inquiry> data = new List<Inquiry>();

            try
            {
                using (var client = GetClient())
                {
                    HttpResponseMessage response = await client.GetAsync("api/inquiry/inquiry/admin");
                    HttpContent result = response.Content;
                    if (response.IsSuccessStatusCode)
                    {
                        //var resString = result.ReadAsStringAsync();
                        var responseData = result.ReadAsAsync<Inquiry[]>();
                        string responseBody = response.Content.ReadAsStringAsync().Result;

                        var inquiry = JsonConvert.DeserializeObject<List<Inquiry>>(responseBody);
                        var items = responseData.Result;
                        foreach (var item in items)
                        {
                            data.Add(item);
                        }
                        return data;
                    }
                    return data;
                }

            }
            catch (AggregateException ex)
            {

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
