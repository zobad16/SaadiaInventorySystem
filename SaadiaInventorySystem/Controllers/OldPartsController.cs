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
    public class OldPartsController : ControllerBase
    {
        public OldPartsController(OldPartService service)
        {
            _service = service;

        }
        private readonly OldPartService _service;
        // GET: api/<OldPartsController>
        [HttpGet("oldparts")]
        public ActionResult<OldPart> Get()
        {
            try
            {
                var oldparts = _service.GetAll();
                if (oldparts != null)
                {
                    return Ok(oldparts);
                }
                else
                    return Conflict("No Old Parts Found");
            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex);
            }
        }

        // GET api/<OldPartsController>/5
        [HttpGet("{id}")]
        public ActionResult<OldPart> Get(string id)
        {
            try
            {
                OldPart oldpart = _service.Get(id);
                if (oldpart != null)
                {
                    return (Ok(oldpart));
                }
                else
                    return Conflict("Inventory not Found");

            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInventoryAsync([FromBody] OldPart op)
        {
            try
            {
                bool success = await _service.AddAsync(op);
                if (success)
                {
                    return Ok("Old part created successfully");
                }
                else
                {
                    return Conflict("Duplicate old part found");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInventoryAsync([FromBody] OldPart op)
        {
            try
            {
                bool success = await _service.UpdateAsync(op);
                if (success)
                {
                    return Ok("OldPart part updated successfully");
                }
                else
                {
                    return Conflict("OldPart part not found");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteOldPartAsync([FromBody] string id)
        {
            try
            {
                bool success = await _service.DeleteAsync(id);
                if (success)
                {
                    return Ok("Old part deleted successfully");
                }
                else
                {
                    return Conflict("Old part part not found");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }




        /*
         [HttpGet("inventory")]
        public ActionResult<List<Inventory>> GetAll()
        {
            try
            {
                var invoices = _inventoryService.GetAll();
                if (invoices != null)
                {
                    return Ok(invoices);
                }
                else
                    return Conflict("No Invoices Found");
            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Inventory> Get(string id)
        {
            try
            {
                Inventory inventory = _inventoryService.Get(id);
                if (inventory != null)
                {
                    return (Ok(inventory));
                }
                else
                    return Conflict("Inventory not Found");

            }
            catch (Exception ex)
            {
                //Log error
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInventoryAsync([FromBody] Inventory inventory)
        {
            try
            {
                bool success = await _inventoryService.AddAsync(inventory);
                if (success)
                {
                    return Ok("Inventory part created successfully");
                }
                else
                {
                    return Conflict("Duplicate Inventory part");
                }
            }
            catch (Exception ex)
            {
                //log
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInventoryAsync([FromBody] Inventory inventory)
        {
            try
            {
                bool success = await _inventoryService.UpdateAsync(inventory);
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
        public async Task<IActionResult> DeleteInvoiceAsync([FromBody] string id)
        {
            try
            {
                bool success = await _inventoryService.DeleteAsync(id);
                if (success)
                {
                    return Ok("Inventory deleted successfully");
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
         
         */
    }
}
