using Newtonsoft.Json;
using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Services
{
    public class LoginService:RestClient
    {
        public LoginService()
        {
            
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
