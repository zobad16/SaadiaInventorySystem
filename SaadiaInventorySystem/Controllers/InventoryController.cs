using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;
        public InventoryController(InventoryService service)
        {
            _inventoryService = service;
        }
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
        [HttpGet("inventory/admin")]
        public ActionResult<List<Inventory>> AdminGetAll()
        {
            try
            {
                var invoices = _inventoryService.AdminGetAll();
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
        public ActionResult<Inventory> Get(int id)
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
        [HttpGet("partno/{id}")]
        public ActionResult<Inventory> GetPartnumber(string part)
        {
            try
            {
                Inventory inventory = _inventoryService.GetByPartNumber(part);
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
        [HttpPost("add/bulk")]
        public async Task<IActionResult> BulkAddInventoryAsync([FromBody] List<Inventory> inventory)
        {
            try
            {
                bool success = await _inventoryService.BulkAddAsync(inventory);
                if (success)
                {
                    return Ok("Inventory Bulk Add successfully");
                }
                else
                {
                    return Conflict("Error Bulk Adding");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Inventory Controller Error: Method: BulkAdd, Error:{ex.InnerException.Message} ");
                return BadRequest();
            }
        }
        [HttpPost("update/bulk")]
        public async Task<IActionResult> UpdateQuotationBulkAsync([FromBody] List<Inventory> inventory)
        {
            try
            {
                bool success = await _inventoryService.BulkUpdateAsync(inventory);
                if (success)
                {
                    return Ok("Inventory updated successfully");
                }
                else
                {
                    return Conflict("Inventory not found");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Inventory Controller Error: Method: Update, Error:{ex.InnerException.Message} ");
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
        [HttpPost("activate")]
        public async Task<IActionResult> ActivateInventoryAsync([FromBody] int id)
        {
            try
            {
                bool success = await _inventoryService.ActivateAsync(id);
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
        [HttpPost("deactivate")]
        public async Task<IActionResult> DeactivateInventoryAsync([FromBody] int id)
        {
            try
            {
                bool success = await _inventoryService.DeactivateAsync(id);
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
        public async Task<IActionResult> DeleteInventoryAsync([FromBody] int id)
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
        [HttpPost("delete/admin")]
        public async Task<IActionResult> AdminDeleteInventoryAsync([FromBody] int id)
        {
            try
            {
                bool success = await _inventoryService.AdminDeleteAsync(id);
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
    }
}