using SaadiaInventorySystem.Model;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class UserService
    {
        public async void CreateUser(Login data)
        { }
        public async Task<Login> GetUser(int id)
        {
            var login = new Login() { UserName = "user1" };
            return login;
        }
    }
}
