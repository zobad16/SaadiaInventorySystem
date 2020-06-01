using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using System;

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        public LoginController()
        {
            //Logging
        }
        [HttpPost("/login")]
        public IActionResult Login(Login data)
        {
            try
            {
                return Ok();
            }

            catch
            {
                return Conflict($"User{data.UserName} not found");

            }
        }

        [HttpPost("/forget")]
        public IActionResult ForgetPassword(Login data)
        {
            return View();
        }

        [HttpPost("/signup")]
        public IActionResult CreateUser(Login data)
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


    }
}