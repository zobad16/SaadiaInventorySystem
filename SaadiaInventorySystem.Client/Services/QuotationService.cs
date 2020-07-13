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
    public class QuotationService:RestClient
    {
        public async Task<bool> CallAddService(Quotation quotation)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/add", quotation);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }

        public async Task<Quotation> CallGetService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/quotation/{id}");
                Quotation data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<Quotation> responseData = result.ReadAsAsync<Quotation>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<Quotation>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/quotation/quotations");
                List<Quotation> data = new List<Quotation>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Quotation>> responseData = result.ReadAsAsync<List<Quotation>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<List<Quotation>> CallAdminGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/quotation/quotations/admin");
                List<Quotation> data = new List<Quotation>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Quotation>> responseData = result.ReadAsAsync<List<Quotation>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(Quotation quotation)
        {
            using (var client = GetClient())
            {                
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/update", quotation);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/activate", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/delete", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallActivateQuotationService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/activate", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallDisableQuotationService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/disable", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/quotation/delete/admin", id);

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
