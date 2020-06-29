using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
                bool exists = _userDao.Users.AsNoTracking().Any(p => p.UserName == data.UserName);
                if (exists) { return false; }
                var user = new User()
                {
                    UserName = data.UserName,
                    FirstName =data.FirstName, 
                    LastName=data.LastName, 
                    Password = data.Password, 
                    RoleFk = data.RoleFk,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now,
                    IsActive = 1,
                    EmailAddress =data.EmailAddress,
                    PhoneNumber =data.PhoneNumber,
                    //Role = data.Role
                    
                };
                    _userDao.Users.Add(user);
                    var res = await _userDao.SaveChangesAsync();
                    return res > 0;
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
                
        }

        public async Task<bool> UpdateUser(User _user)
        {

            try
            {
                bool saved = false;
                User user = (User)_userDao.Users
                            .Where(user => user.Id.Equals(_user.Id)).FirstOrDefault();
                if (user != null)
                {
                    if (! string.IsNullOrEmpty(_user.FirstName)) user.FirstName = _user.FirstName;
                    if (!string.IsNullOrEmpty(_user.LastName)) user.LastName = _user.LastName;
                    if (!string.IsNullOrEmpty(_user.EmailAddress)) user.EmailAddress = _user.EmailAddress;
                    if (!string.IsNullOrEmpty(_user.PhoneNumber )) user.PhoneNumber = _user.PhoneNumber;
                    if(!string.IsNullOrEmpty(_user.Role.Id.ToString()))user.RoleFk = _user.Role.Id;
                    user.DateUpdate = DateTime.Now;
                    
                    saved = await _userDao.SaveChangesAsync() > 0;
                }
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> UpdateUserPassword(User _user)
        {

            try
            {
                bool saved = false;
                User user = (User)_userDao.Users
                            .Where(user => user.Id.Equals(_user.Id)).FirstOrDefault();
                if (user != null)
                {
                    if(!string.IsNullOrEmpty(_user.Password))user.Password= _user.Password;
                    user.DateUpdate = DateTime.Now;
                    
                    saved = await _userDao.SaveChangesAsync() > 0;
                }
                return saved;

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
                    .AsNoTracking()
                    .Include(r => r.Role)
                    .Where(x => x.UserName.Equals(username)).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public User GetUserByUserId(int id)
        {
            try
            {
                User user =(User) _userDao.Users
                    .AsNoTracking()
                    .Include(r=> r.Role)
                    .Where(user => user.Id.Equals(id));
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
                List<User> user = _userDao.Users.AsNoTracking()
                    .Include(r => r.Role).ToList();
                    
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public List<User> AdminGetUsers()
        {
            try
            {
                List<User> user = _userDao.Users
                    .AsNoTracking()
                    .Include(r => r.Role)                
                    .ToList();
                    
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> ActivateUser(int id)
        {
            
            try
            {
                User user = (User)_userDao.Users.Find(id);
                            //.Where(user => user.Id.Equals(id)).FirstOrDefault();
                user.IsActive = 1;
                return await _userDao.SaveChangesAsync() > 0;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            
            try
            {
                User user = (User)_userDao.Users.Find(id);
                            //.Where(user => user.Id.Equals(id)).FirstOrDefault();
                user.IsActive = 0;
                return await _userDao.SaveChangesAsync() > 0;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> AdminDeleteUser(int id)
        {
            
            try
            {
                User user = (User)_userDao.Users
                            .Where(user => user.Id == id).FirstOrDefault();
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
                            .Where(_user => _user.UserName == username && _user.Password == password && _user.IsActive ==1).FirstOrDefault();
                
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
