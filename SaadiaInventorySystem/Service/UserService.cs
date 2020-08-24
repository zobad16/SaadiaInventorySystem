using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SaadiaInventorySystem.Service
{
    public class UserService
    {
        private AppDbContext _userDao;
        private readonly ILogger<UserService> _logger;
        public UserService(AppDbContext dao, ILogger<UserService> logger)
        {
            _userDao = dao;
            _logger = logger;

        }
        public async Task<bool> CreateUser(User data)
        {
            try
            {
                _logger.LogDebug("Service: Creating user");
                bool exists = _userDao.Users.AsNoTracking().Any(p => p.UserName == data.UserName);
                if (exists) 
                {
                    _logger.LogDebug("User creation failed. User already exists");
                    return false; 
                }
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
                if (res > 0)
                {
                    _logger.LogDebug("New User Created successfully");
                }
                else
                {
                    _logger.LogDebug("User creation failed");
                }
                    return res > 0;
                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }
                
        }

        public async Task<bool> UpdateUser(User _user)
        {

            try
            {
                _logger.LogDebug("Updating User");
                bool saved = false;
                User user = (User)_userDao.Users
                            .Where(user => user.Id.Equals(_user.Id)).FirstOrDefault();
                if (user != null)
                {
                    _logger.LogDebug("User Found");
                    if (! string.IsNullOrEmpty(_user.FirstName)) user.FirstName = _user.FirstName;
                    if (!string.IsNullOrEmpty(_user.LastName)) user.LastName = _user.LastName;
                    if (!string.IsNullOrEmpty(_user.EmailAddress)) user.EmailAddress = _user.EmailAddress;
                    if (!string.IsNullOrEmpty(_user.PhoneNumber )) user.PhoneNumber = _user.PhoneNumber;
                    if(!string.IsNullOrEmpty(_user.Role.Id.ToString()))user.RoleFk = _user.Role.Id;
                    user.DateUpdate = DateTime.Now;
                    
                    saved = await _userDao.SaveChangesAsync() > 0;
                    if (saved)
                    {
                        _logger.LogDebug("Update operation successful");
                    }
                    else 
                    {
                        _logger.LogDebug("Update operation failed");
                    }
                }
                _logger.LogDebug("User not found");
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                throw ex;
            }
        }
        public async Task<bool> UpdateUserPassword(User _user)
        {

            try
            {
                _logger.LogDebug("Updating User Password");

                bool saved = false;
                User user = (User)_userDao.Users
                            .Where(user => user.Id.Equals(_user.Id)).FirstOrDefault();
                if (user != null)
                {
                    _logger.LogDebug("User Found. Updating password");
                    if(!string.IsNullOrEmpty(_user.Password))user.Password= _user.Password;
                    user.DateUpdate = DateTime.Now;
                    
                    saved = await _userDao.SaveChangesAsync() > 0;
                }
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }
        }
        public User GetUserByUserName(string username)
        {
            try
            {
                _logger.LogDebug("Getting user by username");
                User user =(User) _userDao.Users
                    .AsNoTracking()
                    .Include(r => r.Role)
                    .Where(x => x.UserName.Equals(username)).FirstOrDefault();
                if (user == null)
                {
                    _logger.LogDebug("User not found");
                    return user;
                }
                _logger.LogDebug("User found");
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;
            }
        }
        public User GetUserByUserId(int id)
        {
            try
            {
                _logger.LogDebug("Getting user by userid");

                User user =(User) _userDao.Users
                    .AsNoTracking()
                    .Include(r=> r.Role)
                    .Where(user => user.Id.Equals(id));
                if (user == null)
                {
                    _logger.LogDebug("User not found");
                    return user;
                }
                _logger.LogDebug("User found");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;
            }
        }
        public List<User> GetUsers()
        {
            try
            {
                _logger.LogDebug("Fetching Users");
                List<User> user = _userDao.Users.AsNoTracking()
                    .Include(r => r.Role).ToList();
                if (user.Count<1)
                {
                    _logger.LogDebug("Fetch operation failed. No record found");
                    return user;
                }
                _logger.LogDebug("Users found");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;
            }
        }
        public List<User> AdminGetUsers()
        {
            try
            {
                _logger.LogDebug("Admin fetching users");
                List<User> user = _userDao.Users
                    .AsNoTracking()
                    .Include(r => r.Role)                
                    .ToList();
                if (user.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No record found");
                    return user;
                }
                _logger.LogDebug("Users found");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;
            }
        }
        public async Task<bool> ActivateUser(int id)
        {
            
            try
            {
                _logger.LogDebug("Activating User");
                bool saved = false;
                User user = (User)_userDao.Users.Find(id);
                if(user == null)
                {
                    _logger.LogDebug("Operation failed. Record not found");
                    return saved;
                }
                            //.Where(user => user.Id.Equals(id)).FirstOrDefault();
                user.IsActive = 1;
                saved = await _userDao.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Activate operation failed.");
                }
                else
                {
                    _logger.LogDebug("Activation operation success");
                }
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            
            try
            {
                bool saved = false;
                _logger.LogDebug("Service: Disabling user");
                User user = (User)_userDao.Users.Find(id);
                if(user == null)
                {
                    _logger.LogDebug("Disable operation failed. User not found");
                    return false;
                }
                            //.Where(user => user.Id.Equals(id)).FirstOrDefault();
                user.IsActive = 0;


                saved = await _userDao.SaveChangesAsync() > 0;
                if(!saved)
                {
                    _logger.LogDebug("Disable operation failed.");
                }
                else 
                {
                    _logger.LogDebug("Disable operaion success");
                }
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }
        }
        public async Task<bool> AdminDeleteUser(int id)
        {
            
            try
            {
                bool saved = false;
                _logger.LogDebug("Service: Admin Delting user");

                User user = (User)_userDao.Users
                            .Where(user => user.Id == id).FirstOrDefault();
                if (user == null)
                {
                    _logger.LogDebug("Delete operation failed. User not found");
                    return false;
                }
                _userDao.Remove<User>(user);
                saved = await _userDao.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Delete operation failed.");
                }
                else
                {
                    _logger.LogDebug("Delete operaion success");
                }
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
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
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }

        }

        
    }
}
