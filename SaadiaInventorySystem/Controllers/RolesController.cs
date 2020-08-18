using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly ILogger<RolesController> _logger;

        public RolesController(RoleService service, ILogger<RolesController> logger)
        {
            _roleService = service;
            _logger = logger;
        }

        // GET: api/<RolesController>/roles
        [HttpGet("roles")]
        public ActionResult<List<Role>> Get()
        {
            try
            {
                _logger.LogDebug("Fetching roles");
                var roles = _roleService.GetAll();
                if (roles != null)
                {
                    _logger.LogDebug("Roles fetch operation success.");
                    return Ok(roles);
                }
                else
                {
                    _logger.LogDebug("Roles fetch operation failed. No roles found");
                    return Conflict("No Roles Found");
                }
            }
            catch (Exception ex)
            {
                //Log error
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
            
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public ActionResult<Role> Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Role by Id");
                var role = _roleService.Get(id);
                if (role != null)
                {
                    _logger.LogDebug("Role fetch operation");
                    return (Ok(role));
                }
                else
                {
                    _logger.LogDebug("Roles fetch operation failed.");
                    return Conflict("Role not Found");
                }

            }
            catch (Exception ex)
            {
                //Log error
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }

        // POST api/<RolesController>
        [HttpPost("add")]
        public async Task<IActionResult> PostAdd([FromBody] Role value)
        {
            try
            {
                _logger.LogDebug("Inserting role");
                bool success = await _roleService.AddAsync(value);
                if (success)
                {
                    _logger.LogDebug("Roles insert operation success.");
                    return Ok("Role created successfully");
                }
                else
                {
                    _logger.LogDebug("Roles insert operation failed. Duplicate role.");
                    return Conflict("Duplicate Role");
                }
            }
            catch (Exception ex)
            {
                //log
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> PostUpdate([FromBody] Role value)
        {
            try
            {
                _logger.LogDebug("Updating Role");
                bool success = await _roleService.UpdateAsync(value);
                if (success)
                {
                    _logger.LogDebug("Role update operation success.");
                    return Ok("Inventory part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Role update operation failed. Role not found.");
                    return Conflict("Role not found");
                }
            }
            catch (Exception ex)
            {
                //log
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> PostDelete([FromBody] string id)
        {
            try
            {
                _logger.LogDebug("Deleting role");
                bool success = await _roleService.DeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Role delete operation success.");
                    return Ok("Role deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Role delete operation failed. Role not found.");
                    return Conflict("Role not found");
                }
            }
            catch (Exception ex)
            {
                //log
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }

        
    }
}
