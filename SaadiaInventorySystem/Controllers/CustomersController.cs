using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(CustomerService service, ILogger<CustomersController> logger)
        {
            _customerService = service;
            _logger = logger;
        }
        // GET: api/<CustomersController>
        [HttpGet("customers")]
        public ActionResult<List<Customer>> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching Customers");
                var customers = _customerService.GetAll();
                if (customers != null)
                {
                    return Ok(customers);
                }
                else
                {
                    _logger.LogDebug("Error fetching customers. No Customer found");
                    return Conflict("No Customers Found");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }
        // GET: api/<CustomersController>
        [HttpGet("admin-customers")]
        public ActionResult<List<Customer>> AdminGetAll()
        {
            try
            {
                _logger.LogDebug("admin Fetching Customers");
                var customers = _customerService.AdminGetAll();
                if (customers != null)
                {
                    _logger.LogDebug("Customers Found");
                    return Ok(customers);
                }
                else
                {
                    _logger.LogDebug("Error fetching customers. No Customers found");
                    return Conflict("No Customers Found");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            try 
            {
                _logger.LogDebug("Fetching Customer");
                var customer = _customerService.Get(id);
                if (customer != null)
                {
                    _logger.LogDebug("Customer Found");
                    return Ok(customer);
                }
                else
                {
                    _logger.LogDebug("Customer not found");
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }

        // POST api/<CustomersController>/update
        [HttpPost("update")]
        public async Task<ActionResult> UpdateCustomerAsync([FromBody] Customer value)
        {
            try
            {
                _logger.LogDebug("Updating Customer");
                var update = await _customerService.UpdateAsync(value);
                if (update)
                {
                    _logger.LogDebug("{first} {last} updated successfully", value.FirstName, value.LastName);
                    return Ok("Successully updated");
                }
                else
                {
                    _logger.LogDebug("{first} {last} not found", value.FirstName,value.LastName);
                    return Conflict("Error! No Customer found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }
        // POST api/<CustomersController>/update
        [HttpPost("activate")]
        public async Task<ActionResult> ActivateCustomerAsync([FromBody] int id)
        {
            try
            {
                _logger.LogDebug("Activating Customer");
                var update = await _customerService.ActivateAsync(id);
                if (update)
                {
                    _logger.LogDebug("Customer Activated");
                    return Ok("Successully updated");
                }
                else
                {
                    _logger.LogDebug("Customer not found");
                    return Conflict("Error! No Customer found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }

        // POST api/<CustomersController>/add
        //[HttpPut("{id}")]
        [HttpPost("add")]
        public async Task<ActionResult> AddCustomerAsync([FromBody] Customer value)
        {
            try
            {
                _logger.LogDebug("Inserting new Customer");
                var add = await _customerService.AddAsync(value);
                if (add)
                {
                    _logger.LogDebug("{firstname} {lastname} added successfully",value.FirstName,value.LastName);
                    return Ok($"Customer{value.FirstName} {value.LastName} added successfully");
                }
                else
                {
                    _logger.LogDebug("{firstname} {lastname} already exists", value.FirstName, value.LastName);
                    return Conflict("Error! Duplicate Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }

        // POST api/<CustomersController>/delete
        [HttpPost("delete")]
        public async Task<ActionResult> DeleteAsync([FromBody]int id)
        {
            try
            {
                _logger.LogDebug("Deleting Customer");
                var delete = await _customerService.DeleteAsync(id);
                if (delete)
                {
                    _logger.LogDebug("Customer deleted successfully", id);
                    return Ok("Customer deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Customer Delete Failed. Customer not found");
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }
        // POST api/<CustomersController>/delete
        [HttpPost("admindelete")]
        public async Task<ActionResult> AdminDeleteAsync([FromBody]int id)
        {
            try
            {
                _logger.LogDebug("Permanently Deleting customer");
                var delete = await _customerService.AdminDeleteAsync(id);
                if (delete)
                {
                    _logger.LogDebug("Customer permanently deleted ");
                    return Ok("Customer permanently deleted successfully");
                }
                else
                {
                    _logger.LogDebug("Customer delete failed. Cusotmer not found", id);
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}
