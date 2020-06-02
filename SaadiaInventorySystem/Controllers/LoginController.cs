using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Controllers
{
    
    
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserService _userService;
        public LoginController(UserService service)
        {
            _userService = service;
            //Logging
        }
        [HttpPost("signin")]
        public IActionResult Login([FromBody] Login data)
        {
            try
            {
                if (_userService.ValidateUser(data.UserName, data.Password))
                {
                    return Ok();
                }
                else 
                {
                    return Conflict($"Invalid User credentials");
                }
            }

            catch
            {
                return Conflict($"User{data.UserName} not found");
            }
        }

        [HttpPost("forget")]
        public IActionResult ForgetPassword(User data)
        {
            return View();
        }

        [HttpPost("signup")]
        public IActionResult CreateUser(User data)
        {
            try
            {
                if (data.UserName != null)
                {
                    //If Success
                    return Ok(data);
                }

            }
            catch (Exception e)
            {
                return Conflict($"{e.Message }");
            }
            return View();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

    }
}