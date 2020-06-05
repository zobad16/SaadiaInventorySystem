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
        public async Task<bool> CreateUser(User data)
        {
            try
            {
                bool isexists = _userDao.Users.Any(x => x.UserName == data.UserName);

                if (!isexists) 
                {
                    await _userDao.Users.AddAsync(data);
                   return await _userDao.SaveChangesAsync() > 0;
                }
                return false;               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
                
        }

        public async Task UpdateUser(User _user)
        {

            try
            {
                User user = (User)_userDao.Users
                            .Where(user => user.Id.Equals(_user.Id)).FirstOrDefault();
                user.FirstName = _user.FirstName;
                user.LastName = _user.LastName;
                user.EmailAddress = _user.EmailAddress;
                user.PhoneNumber = _user.PhoneNumber;
                user.DateUpdate = DateTime.Now;
                
                await _userDao.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public List<User> GetUsers()
        {
            try
            {
                List<User> user = _userDao.Users.ToList();
                    
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> DeleteUser(string id)
        {
            
            try
            {
                User user = (User)_userDao.Users
                            .Where(user => user.UserName.Equals(id));
                user.IsActive = 0;
                return await _userDao.SaveChangesAsync() > 0;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> AdminDeleteUser(string id)
        {
            
            try
            {
                User user = (User)_userDao.Users
                            .Where(user => user.UserName.Equals(id));
                _userDao.Remove<User>(user);
                return await _userDao.SaveChangesAsync() > 0;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                User user = _userDao.Users
                            .Where(_user => _user.UserName == username && _user.Password == password).FirstOrDefault();
                
                if(user!= null)
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
