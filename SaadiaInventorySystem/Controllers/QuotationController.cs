using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly QuotationService _quotationService;
        public QuotationController(QuotationService service)
        {
            _quotationService =service;

        }        
        [HttpGet("quotations")]
        public ActionResult<List<Quotation>> GetAll()
        {
            try
            {
                List<Quotation> quotes = _quotationService.GetAll();
                if (quotes != null)
                {
                    Console.Out.WriteLine("Invoices Found");
                    return Ok(quotes);
                }
                else
                {
                    Console.Out.WriteLine("No Invoices Found");
                    return Conflict("No Invoices Found");

                }
            }
            catch (Exception ex)
            {
                //Log error
                Console.Error.WriteLine($"Quotation Controller Error: Method: Get, Error:{ex.Message} ");
                return BadRequest(ex);
            }
        }
        [HttpGet("quotations/admin")]
        public ActionResult<List<Quotation>> AdminGetAll()
        {
            try
            {
                List<Quotation> quotes = _quotationService.AdminGetAll();
                if (quotes != null)
                {
                    Console.Out.WriteLine("Invoices Found");
                    return Ok(quotes);
                }
                else
                {
                    Console.Out.WriteLine("No Invoices Found");
                    return Conflict("No Invoices Found");

                }
            }
            catch (Exception ex)
            {
                //Log error
                Console.Error.WriteLine($"Quotation Controller Error: Method: Get, Error:{ex.Message} ");
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Quotation> Get(int id)
        {
            try
            {
                Quotation quote = _quotationService.Get(id);
                if (quote != null)
                {
                    return (Ok(quote));
                }
                else
                    return Conflict("Quotation not Found");

            }
            catch (Exception ex)
            {
                //Log 
                Console.Error.WriteLine($"Quotation Controller Error: Method: Get, Error:{ex.Message} ");
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddQuotationAsync([FromBody] Quotation quotation)
        {
            try
            {
                quotation.DateCreated = DateTime.Now;
                quotation.DateUpdated = DateTime.Now;
                quotation.IsActive = 1;

                bool success = await _quotationService.AddAsync(quotation);
                if (success)
                {
                    return Ok("Quotation created successfully");
                }
                else
                {
                    return Conflict("Duplicate Quotation");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Quotation Controller Error: Method: Add, Error:{ex.Message} ");
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateQuotationAsync([FromBody] Quotation quotation)
        {
            try
            {
                bool success = await _quotationService.UpdateAsync(quotation);
                if (success)
                {
                    return Ok("Quotation updated successfully");
                }
                else
                {
                    return Conflict("Quotation not found");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Quotation Controller Error: Method: Update, Error:{ex.Message} ");
                return BadRequest();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteQuotationAsync([FromBody] int id)
        {
            try
            {
                bool success = await _quotationService.DeleteAsync(id);
                if (success)
                {
                    return Ok("Quotation deleted successfully");
                }
                else
                {
                    return Conflict("Quotation part not found");
                }
            }
            catch (Exception ex)
            {
                //log
                
                Console.Error.WriteLine($"Quotation Controller Error: Method: Delete, Error:{ex.Message} ");
                return BadRequest();
            }
        }
        [HttpPost("delete/admin")]
        public async Task<IActionResult> AdminDeleteQuotationAsync([FromBody] int id)
        {
            try
            {
                bool success = await _quotationService.AdminDeleteAsync(id);
                if (success)
                {
                    return Ok("Quotation deleted successfully");
                }
                else
                {
                    return Conflict("Quotation part not found");
                }
            }
            catch (Exception ex)
            {
                //log
                
                Console.Error.WriteLine($"Quotation Controller Error: Method: Delete, Error:{ex.Message} ");
                return BadRequest();
            }
        }
        [HttpPost("activate")]
        public async Task<IActionResult> ActivateInventoryAsync([FromBody] int id)
        {
            try
            {
                bool success = await _quotationService.ActivateAsync(id);
                if (success)
                {
                    return Ok("Quotation successfully activated");
                }
                else
                {
                    return Conflict("Quotation not found");
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