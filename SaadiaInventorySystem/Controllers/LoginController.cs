using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<LoginController> _logger;

        public LoginController(LoginService service, UserService service2, ILogger<LoginController> logger)
        {
            _loginService = service;
            _userService = service2;
            _logger = logger;
            //Logging
        }
        [HttpPost]
        public ActionResult<string> Login([FromBody] Login data)
        {
            
            try
            {
                _logger.LogDebug("Logging in user");
                _logger.LogDebug("Authenticating user");
                if (_loginService.ValidateUser(data.UserName, data.Password))
                {
                    _logger.LogDebug("User Found");
                    string token = Guid.NewGuid().ToString();
                    //create session..
                    SessionData sessionData = new SessionData();
                    sessionData.Token = token;
                    sessionData.User = _userService.GetUserByUserName(data.UserName);

                    SessionManager.GetInstance().CreateSession(token, sessionData);
                    _logger.LogDebug("Generating token");
                    _logger.LogDebug("User Authenticated");
                    return Ok(token);
                }
                else
                {
                    _logger.LogDebug("User not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
            
        }

        [HttpPost("forget")]
        public IActionResult ForgetPassword(User data)
        {
            _logger.LogDebug("Forget password");
            return Ok();
        }

        [HttpPost("signup")]
        public IActionResult CreateUser(User data)
        {
            try
            {
                _logger.LogDebug("User Signup");
                if (data.UserName != null)
                {
                    //If Success
                    var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(data.UserName));
                    _logger.LogDebug("User Created successfully");
                    return Created(resourceUrl, data);
                }
                else 
                {
                    _logger.LogDebug("Signup failed. User already exists");
                    return Conflict("Error: User already Exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);

                return BadRequest();
            }
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

    }
}