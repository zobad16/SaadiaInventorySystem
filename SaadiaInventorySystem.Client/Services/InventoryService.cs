﻿using Newtonsoft.Json;
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
    public class InventoryService:RestClient
    {
        public async Task<bool> CallAddService(Inventory inventory)
        {
            using (var client = GetClient())
            {
                var _inventory = JsonConvert.SerializeObject(inventory);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/inventory/add", _inventory);

                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else return false;

            }
        }

        public async Task<Inventory> CallGetService(string id)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync($"api/inventory/{id}");
                Inventory data;
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<Inventory> responseData = result.ReadAsAsync<Inventory>();
                    data = responseData.Result;
                    return data;
                }
                return null;
            }
        }
        public async Task<List<Inventory>> CallGetAllService()
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/inventory/inventory");
                List<Inventory> data = new List<Inventory>();
                HttpContent result = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    Task<List<Inventory>> responseData = result.ReadAsAsync<List<Inventory>>();
                    data = responseData.Result;
                    return data;
                }
                return data;
            }
        }
        public async Task<bool> CallUpdateService(Inventory inventory)
        {
            using (var client = GetClient())
            {
                var _inventory = JsonConvert.SerializeObject(inventory);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/inventory/update", _inventory);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inventory/delete", id);

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
                HttpResponseMessage response = await client.PostAsJsonAsync("api/inventory/admindelete", id);

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
