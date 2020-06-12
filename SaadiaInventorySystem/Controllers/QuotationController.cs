using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Controllers
{
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
                var invoices = _quotationService.GetAll();
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
        public ActionResult<Quotation> Get(string id)
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
                //Log error
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddQuotationAsync([FromBody] Quotation quotation)
        {
            try
            {
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
                return BadRequest();
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteQuotationAsync([FromBody] string id)
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
                return BadRequest();
            }
        }
    }
}