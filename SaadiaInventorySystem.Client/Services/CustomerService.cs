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
    public class CustomerService:RestClient
    {
        public async Task<bool> CallAddService(Customer customer)
        {
            using (var client = GetClient())
            {
                var _customer = JsonConvert.SerializeObject(customer);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/customers/add", customer);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }
        public async Task<Customer> CallGetService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/customers/{id}");
                Customer data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<Customer> responseData = result.ReadAsAsync<Customer>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<Customer>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/customers/customers");
                List<Customer> data = new List<Customer>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Customer>> responseData = result.ReadAsAsync<List<Customer>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<List<Customer>> CallAdminGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/customers/admin-customers");
                List<Customer> data = new List<Customer>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Customer>> responseData = result.ReadAsAsync<List<Customer>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(Customer customer)
        {
            using (var client = GetClient())
            {
                //var _customer = JsonConvert.SerializeObject(customer);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/customers/update", customer);

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
                //var _customer = JsonConvert.SerializeObject(customer);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/customers/activate", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/customers/delete", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/customers/admindelete", id);

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
