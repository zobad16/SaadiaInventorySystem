using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(UserService service)
        {
            _userService = service;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null) { return BadRequest(); }
            else 
            {
                user.RoleFk = user.Role.Id;
            }
            if (await _userService.CreateUser(user))
            {
                return Ok($"Sucess User: {user.UserName} created!");
            }
            else
            {
                return Conflict("Error: User already Exists");
            }
        }

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] User user)
        {
            if (await _userService.UpdateUser(user))
            {
                return Ok($"Sucess User: {user.UserName} updated!");

            }
            else
            {
                return Conflict("Error: User not found");
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (await _userService.UpdateUserPassword(user))
            {
                return Ok($"Sucess User: {user.UserName} updated!");

            }
            else
            {
                return Conflict("Error: User not found");
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] string id)
        {
            if (await _userService.DeleteUser(id))
            {
                return Ok($"Delete success");
            }
            else
            {
                return BadRequest("User Delete failed");
            }

        }
        [HttpPost("admindelete")]
        public async Task<IActionResult> AdminDeleteUser([FromBody] string id)
        {
            if (await _userService.AdminDeleteUser(id))
            {
                return Ok($"User {id} deleted successfully");
            }
            else
            {
                return BadRequest("User Delete failed");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var _user = _userService.GetUserByUserId(id);
                if (_user.UserName != null)
                {
                    return (Ok(_user));
                }
                else 
                    return Conflict("User not Found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }           

        }
        
        [HttpGet("username/{user}")]
        public async Task<ActionResult<User>> GetUser(string user)
        {
            try
            {
                var _user = _userService.GetUserByUserName(user);
                if (_user.UserName != null)
                {
                    return (Ok(_user));
                }
                else 
                    return Conflict("User not Found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }           

        }

        [HttpGet("users")]
        public ActionResult<List<User>> GetUsers()
        {
            try
            {
                if (IsCurentUserInAdminRole()) 
                {
                    var _user = _userService.GetUsers();
                    if (_user != null)
                    {
                        return (Ok(_user));
                    }
                    else
                        return Conflict("No Users Found");
                }
                return Unauthorized();
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }           

        }
        private bool IsCurentUserInAdminRole()
        {

            string currentRequestToken = Regex.Unescape( Request.Headers[AppProperties.SecurityTokenName]);
            SessionData sessionData = SessionManager.GetInstance().SessionData(currentRequestToken);
            if (sessionData.Token.Equals(currentRequestToken))
            {
                if (AppProperties.USER_ROLE_ADMIN == sessionData.User.Role.RoleName)
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }


    }
}
