using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class LoginService
    {
        private AppDbContext dao;
   
        public LoginService(AppDbContext appDb)
        {
            dao = appDb;
        }
        public bool ValidateUser(string username, string password)
        {
            try
            {
                User user = dao.Users
                            .Where(_user => _user.UserName == username && _user.Password == password).FirstOrDefault();

                if (user != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                //Log
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }

    }
}
