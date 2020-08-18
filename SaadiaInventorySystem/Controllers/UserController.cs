using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using SaadiaInventorySystem.Session;
using SaadiaInventorySystem.Util;

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(UserService service, ILogger<UserController> logger)
        {
            _userService = service;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _logger.LogDebug("Creating User");
            if (user == null) 
            {
                _logger.LogError("User insert operation failed. User is null.");
                return BadRequest(); 
            }
            else 
            {
                user.RoleFk = user.Role.Id;
            }
            if (await _userService.CreateUser(user))
            {
                _logger.LogDebug("User insert operation success.");
                return Ok($"Sucess User: {user.UserName} created!");
            }
            else
            {
                _logger.LogDebug("User insert operation faile. User already exists.");
                return Conflict("Error: User already Exists");
            }
        }

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] User user)
        {
            _logger.LogDebug("Updating user profile");
            if (await _userService.UpdateUser(user))
            {
                _logger.LogDebug("User update operation success");
                return Ok($"Sucess User: {user.UserName} updated!");
            }
            else
            {
                _logger.LogDebug("User update operation failed. User not found.");
                return Conflict("Error: User not found");
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            _logger.LogDebug("Updating user");
            if (await _userService.UpdateUserPassword(user))
            {
                _logger.LogDebug("User update operation success.");
                return Ok($"Sucess User: {user.UserName} updated!");

            }
            else
            {
                _logger.LogDebug("User update operation failed. User not found");
                return Conflict("Error: User not found");
            }
        }

        [HttpPost("activate")]
        public async Task<IActionResult> ActivateUser([FromBody] int id)
        {
            _logger.LogDebug("Activating user.");
            if (await _userService.ActivateUser(id))
            {
                _logger.LogDebug("User activate operation success.");
                return Ok($"Update success");
            }
            else
            {
                _logger.LogDebug("User activate operation failed. User not found.");
                return BadRequest("User Update failed");
            }

        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] int id)
        {
            _logger.LogDebug("Deleting user.");
            if (await _userService.DeleteUser(id))
            {
                _logger.LogDebug("User delete operation success.");
                return Ok($"Delete success");
            }
            else
            {
                _logger.LogDebug("User delete operation failed. User not found.");
                return BadRequest("User Delete failed");
            }

        }
        [HttpPost("admindelete")]
        public async Task<IActionResult> AdminDeleteUser([FromBody] int id)
        {
            _logger.LogDebug("Permanently deleting user.");
            if (await _userService.AdminDeleteUser(id))
            {
                _logger.LogDebug("User permanent delete operation success");
                return Ok($"User {id} deleted successfully");
            }
            else
            {
                _logger.LogDebug("User permanent delete operation failed. User not found.");
                return BadRequest("User Delete failed");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                _logger.LogDebug("Fetching user by Id");
                var _user = _userService.GetUserByUserId(id);
                if (_user.UserName != null)
                {
                    _logger.LogDebug("User fetch operation success.");
                    return (Ok(_user));
                }
                else
                {
                    _logger.LogDebug("User fetch operation failed.");
                    return Conflict("User not Found");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex.Message);
            }           

        }
        
        [HttpGet("username/{user}")]
        public async Task<ActionResult<User>> GetUser(string user)
        {
            try
            {
                _logger.LogDebug("Fetching user by username");
                var _user = _userService.GetUserByUserName(user);
                if (_user.UserName != null)
                {
                    _logger.LogDebug("User fetch operation success");
                    return (Ok(_user));
                }
                else
                {
                    _logger.LogDebug("User fetch operation failed");
                    return Conflict("User not Found");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex.Message);
            }           

        }

        [HttpGet("users")]
        public ActionResult<List<User>> GetUsers()
        {
            try
            {
                _logger.LogDebug("Fetching users");
                if (IsCurentUserInAdminRole()) 
                {
                    var _user = _userService.GetUsers();
                    if (_user != null)
                    {
                        _logger.LogDebug("User fetch operation success.");
                        return (Ok(_user));
                    }
                    else
                    {
                        _logger.LogDebug("User fetch operation failed. No user found");
                        return Conflict("No Users Found");
                    }
                }
                _logger.LogDebug("User Unauthorised");
                return Unauthorized();
                
            }
            catch(Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex.Message);
            }           

        }
        private bool IsCurentUserInAdminRole()
        {
            _logger.LogDebug("Checking user session and role.");
            string currentRequestToken = Regex.Unescape( Request.Headers[AppProperties.SecurityTokenName]);
            SessionData sessionData = SessionManager.GetInstance().SessionData(currentRequestToken);
            if (sessionData.Token.Equals(currentRequestToken))
            {
                _logger.LogDebug("User session found.");
                if (AppProperties.USER_ROLE_ADMIN == sessionData.User.Role.RoleName)
                {
                    _logger.LogDebug("User authenticated as admin.");
                    return true;
                }
                else 
                {
                    _logger.LogDebug("User not authorised for access.");
                    return false; 
                }
            }
            _logger.LogDebug("User session not found.");
            return false;
        }


    }
}
