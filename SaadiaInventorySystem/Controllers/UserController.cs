using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

namespace SaadiaInventorySystem.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        
        public UserController(UserService service)
        {
            _userService = service;
        }
        [HttpPost("CreateUser")]
        public async void CreateUser([FromBody]User user)
        {
            await _userService.CreateUser(user);
        
        }
        
    }
}