using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

namespace SaadiaInventorySystem.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(UserService service)
        {
            _userService = service;
        }
        [HttpPost("signup")]
        public async void CreateUser([FromBody]User user)
        {
            await _userService.CreateUser(user);
        
        }
        [HttpPost("update")]
        public async void UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUser(user);

        }
        [HttpPost("delete")]
        public async void DeleteUser([FromBody] User user)
        {
            await _userService.CreateUser(user);

        }
        

    }
}