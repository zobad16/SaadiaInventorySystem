using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Service
{
    public class UserService
    {
        private AppDbContext _userDao;
        public UserService(AppDbContext dao)
        {
            _userDao = dao;

        }
        public async Task CreateUser(User data)
        {
            try
            {
                await _userDao.Users.AddAsync(data);
                await _userDao.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
                
        }
        public User GetUserByUserName(string username)
        {
            try
            {
                User user =(User) _userDao.Users
                    .Where(user => user.UserName.Equals(username));
                return user;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public List<User> GetUsers()
        {
            try
            {
                List<User> user = _userDao.Users.ToList();
                    
                return user;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void UpdateUser(User _user)
        {
            
            try
            {
                User user = (User)_userDao.Users
                            .Where(user => user.UserName.Equals(_user.Id));
                user = _user;
                _userDao.SaveChangesAsync();
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                var user = _userDao.Users
                            .Where(_user => _user.UserName == username && _user.Password == password);
                if(user.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                //Log
                return false;
            }

        }

        
    }
}
