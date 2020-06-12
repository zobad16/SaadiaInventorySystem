using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService service)
        {
            _customerService = service;
        }
        // GET: api/<CustomersController>
        [HttpGet("customers")]
        public ActionResult<List<Customer>> GetAll()
        {
            try
            {
                var customers = _customerService.GetAll();
                if (customers != null)
                {
                    return Ok(customers);
                }
                else
                {
                    return Conflict("No Customers Found");
                }
            }
            catch(Exception ex)
            {
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
                    return Ok("Successully updated");
                }
                else
                {
                    return Conflict("Error! No Customer found");
                }
            }
            catch (Exception ex)
            {
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
                    return Ok($"Customer{value.FirstName} {value.LastName} added successfully");
                }
                else
                {
                    return Conflict("Error! Duplicate Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<CustomersController>/delete
        [HttpPost("delete")]
        public async Task<ActionResult> DeleteAsync([FromBody]string id)
        {
            try
            {
                var delete = await _customerService.DeleteAsync(id);
                if (delete)
                {
                    return Ok("Customer deleted successfully");
                }
                else
                {
                    return Conflict("No Customers Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
