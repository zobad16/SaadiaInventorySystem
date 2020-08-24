using Microsoft.Extensions.Logging;
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
        private readonly ILogger<LoginService> _logger;
   
        public LoginService(AppDbContext appDb, ILogger<LoginService> logger)
        {
            dao = appDb;
            _logger = logger;
        }
        public bool ValidateUser(string username, string password)
        {
            try
            {
                _logger.LogDebug("Validating user {user}", username);
                User user = dao.Users
                            .Where(_user => _user.UserName == username && _user.Password == password).FirstOrDefault();

                if (user != null)
                {
                    _logger.LogDebug("User {user} Found", username);
                    return true;
                }
                _logger.LogDebug("User {user} not found", username);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }

        }

    }
}
