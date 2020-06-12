using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Controllers
{
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
    }
}