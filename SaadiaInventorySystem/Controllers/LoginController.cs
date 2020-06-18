using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using SaadiaInventorySystem.Session;
using System;
using System.Collections.Generic;
using System.IO;

namespace SaadiaInventorySystem.Controllers
{


    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly UserService _userService;
        public LoginController(LoginService service, UserService service2)
        {
            _loginService = service;
            _userService = service2;
            //Logging
        }
        [HttpPost]
        public ActionResult<string> Login([FromBody] Login data)
        {
            
            try
            {
                if (_loginService.ValidateUser(data.UserName, data.Password))
                {
                    string token = Guid.NewGuid().ToString();
                    //create session..
                    SessionData sessionData = new SessionData();
                    sessionData.Token = token;
                    sessionData.User = _userService.GetUserByUserName(data.UserName);

                    SessionManager.GetInstance().CreateSession(token, sessionData);
                    
                    return Ok(token);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.ToString()});
            }
            
        }

        [HttpPost("forget")]
        public IActionResult ForgetPassword(User data)
        {
            return Ok();
        }

        [HttpPost("signup")]
        public IActionResult CreateUser(User data)
        {
            try
            {
                if (data.UserName != null)
                {
                    //If Success
                    var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(data.UserName));
                    return Created(resourceUrl, data);
                }
                else 
                {
                    return Conflict("Error: User already Exists");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.ToString() });
            }
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

    }
}