using Microsoft.AspNetCore.Mvc;
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
        public InvoiceController(InvoiceService service)
        {
            _invoiceService = service;
        }
        [HttpGet("invoices")]
        public ActionResult<List<Invoice>> GetAll()
        {
            try
            {
                var invoices = _invoiceService.GetAll();
                if(invoices != null)
                {
                    return Ok(invoices);
                }
                else
                    return Conflict("No Invoices Found");
            }
            catch(Exception ex) 
            {
                //Log error
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(string id)
        {
            try
            {
                Invoice invoice = _invoiceService.Get(id);
                if (invoice != null)
                {
                    return (Ok(invoice));
                }
                else
                    return Conflict("Invoice not Found");
                
            }
            catch(Exception ex) 
            {
                //Log error
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInvoiceAsync([FromBody] Invoice invoice)
        {
            try 
            {
                bool success = await _invoiceService.AddAsync(invoice);
                if (success) 
                {
                    return Ok("Invoice created successfully");
                }
                else 
                {
                    return Conflict("Duplicate Invoice");
                }
            }
            catch(Exception ex) 
            {
                //log
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInvoiceAsync([FromBody] Invoice invoice)
        {
            try 
            {
                bool success = await _invoiceService.UpdateAsync(invoice);
                if (success) 
                {
                    return Ok("Invoice updated successfully");
                }
                else 
                {
                    return Conflict("Invoice not found");
                }
            }
            catch(Exception ex) 
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
                bool success = await _invoiceService.DeleteAsync(id);
                if (success) 
                {
                    return Ok("Invoice deleted successfully");
                }
                else 
                {
                    return Conflict("Invoice not found");
                }
            }
            catch(Exception ex) 
            {
                //log
                return BadRequest();
            }
        }

    }
}