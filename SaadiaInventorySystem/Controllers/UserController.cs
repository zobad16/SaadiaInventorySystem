using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

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
            if (await _userService.CreateUser(user))
            {
                return Ok($"Sucess User: {user.UserName} created!");
            }
            else
            {
                return Conflict("Error: User already Exists");
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
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

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] string user)
        {
            if (await _userService.DeleteUser(user))
            {
                return Ok($"User {user} deleted successfully");
            }
            else
            {
                return BadRequest("User Delete failed");
            }

        }

        /*[HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
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

        }*/
        
        [HttpGet("{user}")]
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
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            try
            {
                var _user = _userService.GetUsers();
                if (_user != null)
                {
                    return (Ok(_user));
                }
                else 
                    return Conflict("No Users Found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }           

        }
        

    }
}
