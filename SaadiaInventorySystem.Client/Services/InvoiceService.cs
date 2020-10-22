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
    public class InvoiceService:RestClient
    {
        public async Task<bool> CallAddService(Invoice invoice)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/add", invoice);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallBulkInsert(List<Invoice> quotations)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/add/bulk", quotations);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }
        public async Task<bool> CallBulkUpdate(List<Invoice> quotations)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/update/bulk", quotations);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;
            }
        }

        public async Task<Invoice> CallGetService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/invoice/{id}");
                Invoice data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<Invoice> responseData = result.ReadAsAsync<Invoice>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<Invoice>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/invoice/invoices");
                List<Invoice> data = new List<Invoice>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Invoice>> responseData = result.ReadAsAsync<List<Invoice>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<List<Invoice>> CallAdminGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/invoice/invoices/admin");
                List<Invoice> data = new List<Invoice>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    data = await result.ReadAsAsync<List<Invoice>>();
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(Invoice invoice)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/update", invoice);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/delete", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/delete/admin", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/activate", id);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<bool> CallConfirmService(int id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/invoice/confirm", id);

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
