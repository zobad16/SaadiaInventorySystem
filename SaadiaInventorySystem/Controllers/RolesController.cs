using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RolesController(RoleService service)
        {
            _roleService = service;
        }

        // GET: api/<RolesController>/roles
        [HttpGet("roles")]
        public ActionResult<List<Role>> Get()
        {
            try
            {
                var roles = _roleService.GetAll();
                if (roles != null)
                {
                    return Ok(roles);
                }
                else
                    return Conflict("No Roles Found");
            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex);
            }
            
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public ActionResult<Role> Get(string id)
        {
            try
            {
                var role = _roleService.Get(id);
                if (role != null)
                {
                    return (Ok(role));
                }
                else
                    return Conflict("Role not Found");

            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex);
            }
        }

        // POST api/<RolesController>
        [HttpPost("add")]
        public async Task<IActionResult> PostAdd([FromBody] Role value)
        {
            try
            {
                bool success = await _roleService.AddAsync(value);
                if (success)
                {
                    return Ok("Role created successfully");
                }
                else
                {
                    return Conflict("Duplicate Role");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> PostUpdate([FromBody] Role value)
        {
            try
            {
                bool success = await _roleService.UpdateAsync(value);
                if (success)
                {
                    return Ok("Inventory part updated successfully");
                }
                else
                {
                    return Conflict("Inventory part not found");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> PostDelete([FromBody] string id)
        {
            try
            {
                bool success = await _roleService.DeleteAsync(id);
                if (success)
                {
                    return Ok("Role deleted successfully");
                }
                else
                {
                    return Conflict("Role not found");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }

        
    }
}
