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
                _logger.LogInformation("Fetching Customers");
                var customers = _customerService.GetAll();
                if (customers != null)
                {
                    return Ok(customers);
                }
                else
                {
                    _logger.LogInformation("Error fetching customers. No Customer found");
                    return Conflict("No Customers Found");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An exception occured while fetching customers data.");
                return BadRequest(ex);
            }
        }
        // GET: api/<CustomersController>
        [HttpGet("admin-customers")]
        public ActionResult<List<Customer>> AdminGetAll()
        {
            try
            {
                _logger.LogInformation("Fetching Customers");
                var customers = _customerService.AdminGetAll();
                if (customers != null)
                {
                    return Ok(customers);
                }
                else
                {
                    _logger.LogInformation("Error fetching customers. No Customer found");
                    return Conflict("No Customers Found");
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An exception occured while fetching customers data.");
                return BadRequest(ex);
            }
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            try 
            {
                var customer = _customerService.Get(id);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occured while fetching customer data.");
                return BadRequest(ex);
            }
        }

        // POST api/<CustomersController>/update
        [HttpPost("update")]
        public async Task<ActionResult> UpdateCustomerAsync([FromBody] Customer value)
        {
            try
            {
                var update = await _customerService.UpdateAsync(value);
                if (update)
                {
                    _logger.LogInformation("{first} {last} updated successfully", value.FirstName, value.LastName);
                    return Ok("Successully updated");
                }
                else
                {
                    _logger.LogError("{first} {last} not found", value.FirstName,value.LastName);
                    return Conflict("Error! No Customer found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occured while updating customers data.");
                return BadRequest(ex);
            }
        }
        // POST api/<CustomersController>/update
        [HttpPost("activate")]
        public async Task<ActionResult> ActivateCustomerAsync([FromBody] int id)
        {
            try
            {
                var update = await _customerService.ActivateAsync(id);
                if (update)
                {
                    _logger.LogInformation("Customer with customer id:{id} updated", id);
                    return Ok("Successully updated");
                }
                else
                {
                    _logger.LogInformation("Customer with Id:{id} not found", id);
                    return Conflict("Error! No Customer found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occured.");
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
                var add = await _customerService.AddAsync(value);
                if (add)
                {
                    _logger.LogInformation("{firstname} {lastname} added successfully",value.FirstName,value.LastName);
                    return Ok($"Customer{value.FirstName} {value.LastName} added successfully");
                }
                else
                {
                    _logger.LogInformation("{firstname} {lastname} already exists", value.FirstName, value.LastName);
                    return Conflict("Error! Duplicate Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occured while adding a new customer.");
                return BadRequest(ex);
            }
        }

        // POST api/<CustomersController>/delete
        [HttpPost("delete")]
        public async Task<ActionResult> DeleteAsync([FromBody]int id)
        {
            try
            {
                var delete = await _customerService.DeleteAsync(id);
                if (delete)
                {
                    _logger.LogInformation("Customer with CustomerId{customerid} deleted", id);
                    return Ok("Customer deleted successfully");
                }
                else
                {
                    _logger.LogInformation("Customer with CustomerId{customerid} not found", id);
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occured while deleting a customer.");
                return BadRequest(ex);
            }
        }
        // POST api/<CustomersController>/delete
        [HttpPost("admindelete")]
        public async Task<ActionResult> AdminDeleteAsync([FromBody]int id)
        {
            try
            {
                var delete = await _customerService.AdminDeleteAsync(id);
                if (delete)
                {
                    _logger.LogInformation("Customer with CustomerId{customerid} deleted",id);
                    return Ok("Customer permanently deleted successfully");
                }
                else
                {
                    _logger.LogInformation("Customer with CustomerId{customerid} not found", id);
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occured while deleting a customer.");
                return BadRequest(ex);
            }
        }
    }
}
