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
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return new Customer[] { new Customer() { FirstName="Customer value1", LastName="Customer value2" } };
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>/update
        [HttpPost("update")]
        public void UpdateCustomer([FromBody] Customer value)
        {
        }

        // POST api/<CustomersController>/add
        //[HttpPut("{id}")]
        [HttpPost("add")]
        public void AddCustomer([FromBody] Customer value)
        {
        }

        // POST api/<CustomersController>/delete
        [HttpPost("delete")]
        public void Delete([FromBody]string customer)
        {
        }
    }
}
