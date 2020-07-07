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
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrdersController(OrderService service)
        {
            _orderService = service;
        }
        // GET: api/<OrdersController>
        [HttpGet("orders")]
        public ActionResult<List<Order>> GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }
        [HttpGet("orders/admin")]
        public ActionResult<List<Order>> GetAllAdmin()
        {
            var orders = _orderService.AdminGetAll();
            return Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderService.Get(id);
            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost("update")]
        public async Task<ActionResult> UpdatePostAsync([FromBody] Order value)
        {
            if (await _orderService.UpdateAsync(value))
            {
                return Ok();
            }
            return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("create")]
        public async Task <ActionResult> CreatePostAsync([FromBody] Order value)
        {
            if(await _orderService.AddAsync(value)) 
            {
                return Ok();
            }
            return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("delete")]
        public async Task<ActionResult> DeletePostAsync([FromBody] int id)
        {
            bool success = await _orderService.DeleteAsync(id);

            if (success) return Ok();
            else return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("delete/admin")]
        public async Task<ActionResult> AdminDeletePost([FromBody] int id)
        {
            bool success = await _orderService.AdminDeleteAsync(id);
            if (success) return Ok();
            else return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("activate")]
        public async Task<ActionResult> ActivatePost([FromBody] int id)
        {
            bool success = await _orderService.ActivateAsync( id);
            if (success) return Ok();
            else return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("disable")]
        public async Task< ActionResult >DisablePost([FromBody] int id)
        {
            bool success = await _orderService.DeleteAsync(id);
            if (success) return Ok();
            else return BadRequest();
        }

    }
}
