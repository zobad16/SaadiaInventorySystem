using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace SaadiaInventorySystem.Controllers
{


    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService service)
        {
            _loginService = service;
            //Logging
        }
        [HttpPost]
        public ActionResult<string> Login([FromBody] Login data)
        {
            try
            {
                if (_loginService.ValidateUser(data.UserName, data.Password))
                {
                    return Ok($"User:{data.UserName} sucessdully loggedin");
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