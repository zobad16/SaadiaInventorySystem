using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class InquiryController : ControllerBase
    {
        private readonly ILogger<InquiryController> _logger;
        private readonly IInquiryService _inquiryService;
        public InquiryController(IInquiryService service, ILogger<InquiryController> logger)
        {
            _logger = logger;
            _inquiryService = service;
        }
        [HttpGet("inquiry")]
        public async Task<ActionResult<List<Inquiry>>> GetAllAsync()
        {
            try
            {
                _logger.LogDebug("Fetching Inquiries");
                var inquiry = _inquiryService.GetAll();
                if (inquiry != null)
                {
                    _logger.LogDebug("Inquiries Found. Returning fetched Inquiries.");
                    return Ok(inquiry);
                }
                else
                {
                    _logger.LogDebug("No Inquiries Found");
                    return Conflict("No Inquiries Found");
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
        [HttpGet("inquiry/admin")]
        public ActionResult<List<Inquiry>> AdminGetAll()
        {
            try
            {
                _logger.LogDebug("Fetching all Inquiries");
                var inquiry = _inquiryService.AdminGetAll();
                if (inquiry != null)
                {
                    _logger.LogDebug("Inquiries Found. Returning Inquiries");
                    return Ok(inquiry);
                }
                else
                {
                    _logger.LogDebug("No Inquiries found");
                    return Conflict("No Inquiries Found");
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
        [HttpGet]
        public async Task<ActionResult<Inquiry>> GetAsync(int id)
        {
            try
            {
                _logger.LogDebug("Fetching Inquiry Item");
                var inquiry = await _inquiryService.Get(id);
                if (inquiry != null)
                {
                    _logger.LogDebug("Inquiry Item found. Returning Fetched Item");
                    return (Ok(inquiry));
                }
                else
                {
                    _logger.LogDebug("Inquiry Item not found");
                    return Conflict("Inquiry not Found");
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
        public async Task<IActionResult> AddInquiryAsync([FromBody] Inquiry inquiry)
        {
            try
            {
                _logger.LogDebug("Inserting new Inquiry Part");
                bool success = await _inquiryService.AddAsync(inquiry);
                if (success)
                {
                    _logger.LogDebug("Inquiry Part Inserted successfully ");
                    return Ok("Inquiry part created successfully");
                }
                else
                {
                    _logger.LogDebug("Inquiry Insert failed. Duplicate Inquiry part found");
                    return Conflict("Duplicate Inquiry part");
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
        public async Task<IActionResult> BulkAddInquiryAsync([FromBody] List<Inquiry> inquiry)
        {
            try
            {
                _logger.LogDebug("Bulk inserting inquiry parts");
                bool success = await _inquiryService.BulkAddAsync(inquiry);
                if (success)
                {
                    _logger.LogDebug("Bulk Insert Sucess");
                    return Ok("Inquiry Bulk Add successfully");
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
                Console.Error.WriteLine($"Inquiry Controller Error: Method: BulkAdd, Error:{ex.InnerException.Message} ");
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("update/bulk")]
        public async Task<IActionResult> UpdateInquiryBulkAsync([FromBody] List<Inquiry> inquiry)
        {
            try
            {
                _logger.LogDebug("Bulk Updating Inquiry");
                bool success = await _inquiryService.BulkUpdateAsync(inquiry);
                if (success)
                {
                    _logger.LogDebug("Bulk update success");
                    return Ok("Inquiry updated successfully");
                }
                else
                {
                    _logger.LogDebug("Bulk Update Failed");
                    return Conflict("Inquiry not found");
                }
            }
            catch (Exception ex)
            {
                //log
                Console.Error.WriteLine($"Inquiry Controller Error: Method: Update, Error:{ex.InnerException.Message} ");
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateInquiryAsync([FromBody] Inquiry inquiry)
        {
            try
            {
                _logger.LogDebug("Updating Inquiry");
                bool success = await _inquiryService.UpdateAsync(inquiry);
                if (success)
                {
                    _logger.LogDebug("Inquiry update successfully");
                    return Ok("Inquiry part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Inquiry update failed. Inquiry part not found");
                    return Conflict("Inquiry part not found");
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
        public async Task<IActionResult> ActivateInquiryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Activating inquiry Part");
                bool success = await _inquiryService.ActivateAsync(id);
                if (success)
                {
                    _logger.LogDebug("inquiry part updated.");
                    return Ok("inquiry part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Update failed. Inquiry Part not Found");
                    return Conflict("Inquiry part not found");
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
        [HttpPost("disable")]
        public async Task<IActionResult> DeactivateInquiryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Deavtivating Inventory part");
                bool success = await _inquiryService.DeactivateAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inquiry updated");
                    return Ok("Inventory part updated successfully");
                }
                else
                {
                    _logger.LogDebug("Inquiry update failed. Inquiry part not found");
                    return Conflict("Inquiry part not found");
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
        public async Task<IActionResult> DeleteInquiryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Deleting inventory part");
                bool success = await _inquiryService.DeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inquiry part deleted");
                    return Ok("Inquiry deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Inquiry delete operation failed. Inventory part not found.");
                    return Conflict("Inquiry part not found");
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
        public async Task<IActionResult> AdminDeleteInquiryAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Permanently deleting Inquiry");
                bool success = await _inquiryService.AdminDeleteAsync(id);
                if (success)
                {
                    _logger.LogDebug("Inquiry part permanently deleted.");
                    return Ok("Inquiry deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Inquiry delete operation failed. Inventory part not found");
                    return Conflict("Inquiry part not found");
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
