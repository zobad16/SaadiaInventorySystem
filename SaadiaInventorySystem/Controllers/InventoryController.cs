using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<InventoryController> _logger;
        private readonly InventoryService _inventoryService;
        public InventoryController(InventoryService service, ILogger<InventoryController> logger)
        {
            _logger = logger;
            _inventoryService = service;
        }
        [HttpGet("inventory")]
        public ActionResult<List<Inventory>> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching inventories");
                var invoices = _inventoryService.GetAll();
                if (invoices != null)
                {
                    _logger.LogDebug("Inventories Found. Returning fetched inventories.");
                    return Ok(invoices);
                }
                else
                {
                    _logger.LogDebug("No Inventories Found");
                    return Conflict("No inventories Found");
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
        [HttpGet("inventory/admin")]
        public ActionResult<List<Inventory>> AdminGetAll()
        {
            try
            {
                _logger.LogDebug("Fetching all inventories");
                var invoices = _inventoryService.AdminGetAll();
                if (invoices != null)
                {
                    _logger.LogDebug("Inventories Found. Returning invoices");
                    return Ok(invoices);
                }
                else
                {
                    _logger.LogDebug("No Inventories found");
                    return Conflict("No Inventories Found"); 
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
        [HttpGet("{id}")]
        public ActionResult<Inventory> Get(int id)
        {
            try
            {
                _logger.LogDebug("Fetching Inventory Item");
                Inventory inventory = _inventoryService.Get(id);
                if (inventory != null)
                {
                    _logger.LogDebug("Inventory Item found. Returning Fetched Item");
                    return (Ok(inventory));
                }
                else
                {
                    _logger.LogDebug("Inventory Item not found");
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
        [HttpGet("partno/{id}")]
        public ActionResult<Inventory> GetPartnumber(string part)
        {
            try
            {
                _logger.LogDebug("Fetching Inventory Item based on part number");
                Inventory inventory = _inventoryService.GetByPartNumber(part);
                if (inventory != null)
                {
                    _logger.LogDebug("Inventory part found. Returning fetched part");
                    return (Ok(inventory));
                }
                else
                {
                    _logger.LogDebug("Inventory Part not found");
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
        public async Task<IActionResult> AddInventoryAsync([FromBody] Inventory inventory)
        {
            try
            {
                _logger.LogDebug("Inserting new Inventory Part");
                bool success = await _inventoryService.AddAsync(inventory);
                if (success)
                {
                    _logger.LogDebug("Inventory Part Inserted successfully ");
                    return Ok("Inventory part created successfully");
                }
                else
                {
                    _logger.LogDebug("Inventory Insert failed. Duplicate Inventory part found");
                    return Conflict("Duplicate Inventory part");
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
        [HttpPost("add/bulk")]
        public async Task<IActionResult> BulkAddInventoryAsync([FromBody] List<Inventory> inventory)
        {
            try
            {
                _logger.LogDebug("Bulk inserting Inventory parts");
                bool success = await _inventoryService.BulkAddAsync(inventory);
                if (success)
                {
                    _logger.LogDebug("Bulk Insert Sucess");
                    return Ok("Inventory Bulk Add successfully");
                }
                else
                {
                    _logger.LogDebug("Bulk Insert Failed");
                    return Conflict("Error Bulk Adding");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Inventory Controller Error: Method: BulkAdd, Error:{ex.InnerException.Message} ");
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("update/bulk")]
        public async Task<IActionResult> UpdateInventoryBulkAsync([FromBody] List<Inventory> inventory)
        {
            try
            {
                _logger.LogDebug("Bulk Updating Inventory");
                bool success = await _inventoryService.BulkUpdateAsync(inventory);
                if (success)
                {
                    _logger.LogDebug("Bulk update success");
                    return Ok("Inventory updated successfully");
                }
                else
                {
                    _logger.LogDebug("Bulk Update Failed");
                    return Conflict("Inventory not found");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Inventory Controller Error: Method: Update, Error:{ex.InnerException.Message} ");
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInventoryAsync([FromBody] Inventory inventory)
        {
            try
            {
                _logger.LogDebug("Updating Inventory");
                bool success = await _inventoryService.UpdateAsync(inventory);
                if (success)
                {
                    _logger.LogDebug("Inventory update successfully");
                    return Ok("Inventory part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Inventory update failed. Inventory part not found");
                    return Conflict("Inventory part not found");
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
        [HttpPost("activate")]
        public async Task<IActionResult> ActivateInventoryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Activating Inventory Part");
                bool success = await _inventoryService.ActivateAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inventory part updated.");
                    return Ok("Inventory part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Update failed. Inventory Part not Found");
                    return Conflict("Inventory part not found");
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
        [HttpPost("deactivate")]
        public async Task<IActionResult> DeactivateInventoryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Deavtivating Inventory part");
                bool success = await _inventoryService.DeactivateAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inventory updated");
                    return Ok("Inventory part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Inventory update failed. Inventory part not found");
                    return Conflict("Inventory part not found");
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
        public async Task<IActionResult> DeleteInventoryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Deleting inventory part");
                bool success = await _inventoryService.DeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inventory part deleted");
                    return Ok("Inventory deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Inventory delete operation failed. Inventory part not found.");
                    return Conflict("Inventory part not found");
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
        [HttpPost("delete/admin")]
        public async Task<IActionResult> AdminDeleteInventoryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Permanently deleting Inventory");
                bool success = await _inventoryService.AdminDeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inventory part permanently deleted.");
                    return Ok("Inventory deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Inventory delete operation failed. Inventory part not found");
                    return Conflict("Inventory part not found");
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