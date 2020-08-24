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
    public class QuotationController : ControllerBase
    {
        private readonly QuotationService _quotationService;
        private readonly ILogger<QuotationController> _logger;

        public QuotationController(QuotationService service, ILogger<QuotationController> logger)
        {
            _quotationService =service;
            _logger = logger;

        }        
        [HttpGet("quotations")]
        public ActionResult<List<Quotation>> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching all quotations");
                List<Quotation> quotes = _quotationService.GetAll();
                if (quotes != null)
                {
                    _logger.LogDebug("Quotation Fetch Operation Successful");
                    return Ok(quotes);
                }
                else
                {
                    _logger.LogDebug("Quotation Fetch Operation Failed. No Invoices Found.");
                    return Conflict("No Invoices Found");

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
        [HttpGet("quotations/admin")]
        public ActionResult<List<Quotation>> AdminGetAll()
        {
            try
            {
                _logger.LogDebug("Admin fetching all quotations");
                List<Quotation> quotes = _quotationService.AdminGetAll();
                if (quotes != null)
                {
                    _logger.LogDebug("Quotations fetch operation success.");
                    return Ok(quotes);
                }
                else
                {
                    _logger.LogDebug("Quotations fetch operation failed. No invoices found");
                    return Conflict("No Invoices Found");

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
        public ActionResult<Quotation> Get(int id)
        {
            try
            {
                _logger.LogDebug("Fetching Quotation");
                Quotation quote = _quotationService.Get(id);
                if (quote != null)
                {
                    _logger.LogDebug("Quotation fetch operation success.");
                    return (Ok(quote));
                }
                else
                {
                    _logger.LogDebug("Quotation fetch operation failed. Quoatation not found.");
                    return Conflict("Quotation not Found");
                }

            }
            catch (Exception ex)
            {
                //Log 
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddQuotationAsync([FromBody] Quotation quotation)
        {
            try
            {
                _logger.LogDebug("Adding new quotation");
                quotation.DateCreated = DateTime.Now;
                quotation.DateUpdated = DateTime.Now;
                quotation.IsActive = 1;

                bool success = await _quotationService.AddAsync(quotation);
                if (success)
                {
                    _logger.LogDebug("Quoatation insert operation success.");
                    return Ok("Quotation created successfully");
                }
                else
                {
                    _logger.LogDebug("Quoation insert operation failed. Quoatation already exists.");
                    return Conflict("Duplicate Quotation");
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
        public async Task<IActionResult> BulkAddQuotationAsync([FromBody] List<Quotation> quotation)
        {
            try
            {
                _logger.LogDebug("Bulk inserting quoatations");
                bool success = await _quotationService.BulkAddAsync(quotation);
                if (success)
                {
                    _logger.LogDebug("Quotation bulk insert operation success.");
                    return Ok("Quotation Bulk Add successfully");
                }
                else
                {
                    _logger.LogDebug("Quotation bulk insert operation failed. Duplicate quotations found");
                    return Conflict("Duplicate Quotation");
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
        public async Task<IActionResult> UpdateQuotationAsync([FromBody] Quotation quotation)
        {
            try
            {
                _logger.LogDebug("Updating quotations");
                bool success = await _quotationService.UpdateAsync(quotation);
                if (success)
                {
                    _logger.LogDebug("Quotation update operation success.");
                    return Ok("Quotation updated successfully");
                }
                else
                {
                    _logger.LogDebug("Quoation update operation failed. Quotation not found.");
                    return Conflict("Quotation not found");
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
         [HttpPost("update/bulk")]
        public async Task<IActionResult> UpdateQuotationBulkAsync([FromBody] List<Quotation> quotation)
        {
            try
            {
                _logger.LogDebug("Quotation bulk updating");
                bool success = await _quotationService.BulkUpdateAsync(quotation);
                if (success)
                {
                    _logger.LogDebug("Bulk update operation success.");
                    return Ok("Quotation updated successfully");
                }
                else
                {
                    _logger.LogDebug("Quotation bulk update failed. Quotation not found");
                    return Conflict("Quotation not found");
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
        public async Task<IActionResult> DeleteQuotationAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Quotation deleting");
                bool success = await _quotationService.DeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Quotation delete operation success.");
                    return Ok("Quotation deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Quotation delete operation failed. Quotation not found");
                    return Conflict("Quotation part not found");
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
        public async Task<IActionResult> AdminDeleteQuotationAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Permanently deleting quotation");
                bool success = await _quotationService.AdminDeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Permanent delete operation success.");
                    return Ok("Quotation deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Quotation permanent delete operation failed. Quotation not found.");
                    return Conflict("Quotation part not found");
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
        public async Task<IActionResult> ActivateQuotationAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Quotation activating");
                bool success = await _quotationService.ActivateAsync(id);
                if (success)
                {
                    _logger.LogDebug("Quotation activate operation success.");
                    return Ok("Quotation successfully activated");
                }
                else
                {
                    _logger.LogDebug("Quotation activate operation failed. Quotation not found.");
                    return Conflict("Quotation not found");
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