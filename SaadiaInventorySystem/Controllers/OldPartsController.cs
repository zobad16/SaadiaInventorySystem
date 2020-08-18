using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class OldPartsController : ControllerBase
    {
        private readonly OldPartService _service;
        private readonly ILogger<OldPartsController> _logger;
        
        public OldPartsController(OldPartService service, ILogger<OldPartsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        

        // GET: api/<OldPartsController>
        [HttpGet("oldparts")]
        public ActionResult<List<OldPart>> Get()
        {
            try
            {
                _logger.LogDebug("Fetching Old Part");
                var oldparts = _service.GetAll();
                if (oldparts != null)
                {
                    _logger.LogDebug("Old Parts Found. Returning Old Parts found");
                    return Ok(oldparts);
                }
                else
                {
                    _logger.LogDebug("Fetch operation failed. No parts found");
                    return Conflict("No Old Parts Found");
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

        // GET api/<OldPartsController>/5
        [HttpGet("{id}")]
        public ActionResult<OldPart> Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Old Part");
                OldPart oldpart = _service.Get(id);
                if (oldpart != null)
                {
                    _logger.LogDebug("Old Parts Found. Returning parts found");
                    return (Ok(oldpart));
                }
                else
                {
                    _logger.LogDebug("Fetch operation failed. Old part not found");
                    return Conflict("Inventory not Found");
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
        [HttpPost("add")]
        public async Task<IActionResult> AddInventoryAsync([FromBody] OldPart op)
        {
            try
            {
                _logger.LogDebug("Inserting a new record");
                bool success = await _service.AddAsync(op);
                if (success)
                {
                    _logger.LogDebug("Insert Operataion success");
                    return Ok("Old part created successfully");
                }
                else
                {
                    _logger.LogDebug("Insert operation failed. A duplicate Part already exists");
                    return Conflict("Duplicate old part found");
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
        public async Task<IActionResult> UpdateInventoryAsync([FromBody] OldPart op)
        {
            try
            {
                _logger.LogDebug("Updating Old Inventory parts");
                bool success = await _service.UpdateAsync(op);
                if (success)
                {
                    _logger.LogDebug("Update operation success.");
                    return Ok("OldPart part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Update operation failed. Old Part not found");
                    return Conflict("OldPart part not found");
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
        public async Task<IActionResult> DeleteOldPartAsync([FromBody] string id)
        {
            try
            {
                _logger.LogDebug("Deleting Old Part");
                bool success = await _service.DeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Delete Operation success.");
                    return Ok("Old part deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Delete Operation failed. Old part not found.");
                    return Conflict("Old part part not found");
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
