using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(InvoiceService service, ILogger<InvoiceController> logger)
        {
            _invoiceService = service;
            _logger = logger;
        }
        [HttpGet("invoices")]
        public ActionResult<List<Invoice>> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching Invoices");
                var invoices = _invoiceService.GetAll();
                if (invoices != null)
                {
                    _logger.LogDebug("Invoices fetched successfully");
                    return Ok(invoices);
                }
                else
                {
                    _logger.LogDebug("No Invoice found");
                    return Conflict("No Invoices Found");
                }
            }
            catch(Exception ex) 
            {
                //Log error
                _logger.LogError("An Exception occured: {ex}",ex.Message);
                _logger.LogError("Stack Trace: {ex}",ex.StackTrace);
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Invoice");
                Invoice invoice = _invoiceService.Get(id);
                if (invoice != null)
                {
                    _logger.LogDebug("Invoice found. Returning Invoice");
                    return (Ok(invoice));
                }
                else
                {
                    _logger.LogDebug("Invoice not found");
                    return Conflict("Invoice not Found");
                }
                
            }
            catch(Exception ex) 
            {
                //Log error
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInvoiceAsync([FromBody] Invoice invoice)
        {
            try 
            {
                _logger.LogDebug("Inserting new Invoice");
                bool success = await _invoiceService.AddAsync(invoice);
                if (success) 
                {
                    _logger.LogDebug("Invoice inserted successfully");
                    return Ok("Invoice created successfully");
                }
                else 
                {
                    _logger.LogDebug("Invoice insert failed. Duplicate invoice found");
                    return Conflict("Duplicate Invoice");
                }
            }
            catch(Exception ex) 
            {
                //log
                _logger.LogError("Add invoice failed. An exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInvoiceAsync([FromBody] Invoice invoice)
        {
            try 
            {
                _logger.LogDebug("Updating Invoice");
                bool success = await _invoiceService.UpdateAsync(invoice);
                if (success) 
                {
                    _logger.LogDebug("Update Successfull");
                    return Ok("Invoice updated successfully");
                }
                else 
                {
                    _logger.LogDebug("Update Failed. Invoice not found");
                    return Conflict("Invoice not found");
                }
            }
            catch(Exception ex) 
            {
                //log
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteInvoiceAsync([FromBody] string id)
        {
            try 
            {
                _logger.LogDebug("Deleting Invoice");
                bool success = await _invoiceService.DeleteAsync(id);
                if (success) 
                {
                    _logger.LogDebug("Delete successfull");
                    return Ok("Invoice deleted successfully");
                }
                else 
                {
                    _logger.LogDebug("Delete failed. Invoice not found");
                    return Conflict("Invoice not found");
                }
            }
            catch(Exception ex) 
            {
                //log
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }

    }
}