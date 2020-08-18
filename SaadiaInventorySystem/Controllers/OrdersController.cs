using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Model;
using SaadiaInventorySystem.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaadiaInventorySystem.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(OrderService service, ILogger<OrdersController> logger)
        {
            _orderService = service;
            _logger = logger;
        }
        // GET: api/<OrdersController>
        [HttpGet("orders")]
        public ActionResult<List<Order>> GetAll()
        {
            _logger.LogDebug("Fetching All Orders");
            var orders = _orderService.GetAll();
            _logger.LogDebug("Orders Fetch operation success.");
            return Ok(orders);
        }
        [HttpGet("orders/admin")]
        public ActionResult<List<Order>> GetAllAdmin()
        {
            _logger.LogDebug("Admin Fetching Orders");
            var orders = _orderService.AdminGetAll();
            _logger.LogDebug("Admin Fetch Operation Success.");
            return Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            _logger.LogDebug("Fetching Order by Id");
            var order = _orderService.Get(id);
            _logger.LogDebug("Fetch Operation success");
            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost("update")]
        public async Task<ActionResult> UpdatePostAsync([FromBody] Order value)
        {
            _logger.LogDebug("Updaing Order");
            if (await _orderService.UpdateAsync(value))
            {
                _logger.LogDebug("Update Operation Success");
                return Ok();
            }
            _logger.LogDebug("Update Operation Failed. Order Not found");
            return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("create")]
        public async Task <ActionResult> CreatePostAsync([FromBody] Order value)
        {
            _logger.LogDebug("Inserting Order");
            if (await _orderService.AddAsync(value)) 
            {
                _logger.LogDebug("Insert operation Success.");
                return Ok();
            }
            _logger.LogDebug("Insert operation failed");
            return BadRequest();
        }
        // POST api/<OrdersController>
        [HttpPost("delete")]
        public async Task<ActionResult> DeletePostAsync([FromBody] int id)
        {
            _logger.LogDebug("Deleting Order");
            bool success = await _orderService.DeleteAsync(id);

            if (success)
            {
                _logger.LogDebug("Delete Operation Success.");
                return Ok();
            }
            else
            {
                _logger.LogDebug("Delete Operation failed. Order not found");
                return BadRequest();
            }
        }
        // POST api/<OrdersController>
        [HttpPost("delete/admin")]
        public async Task<ActionResult> AdminDeletePost([FromBody] int id)
        {
            _logger.LogDebug("Order Permanently deleting");
            bool success = await _orderService.AdminDeleteAsync(id);
            if (success)
            {
                _logger.LogDebug("Delete Operation Success");
                return Ok();
            }
            else
            {
                _logger.LogDebug("Delete Operation failed");
                return BadRequest();
            }
        }
        // POST api/<OrdersController>
        [HttpPost("activate")]
        public async Task<ActionResult> ActivatePost([FromBody] int id)
        {
            _logger.LogDebug("Activating order");
            bool success = await _orderService.ActivateAsync( id);
            if (success)
            {
                _logger.LogDebug("Activating operation success");
                return Ok();
            }
            else
            {
                _logger.LogDebug("Activate operation failed. Order Not found.");
                return BadRequest();
            }
        }
        // POST api/<OrdersController>
        [HttpPost("disable")]
        public async Task< ActionResult >DisablePost([FromBody] int id)
        {
            _logger.LogDebug("Disabling order");
            bool success = await _orderService.DeleteAsync(id);
            if (success)
            {
                _logger.LogDebug("Disable operation success.");
                return Ok();
            }
            else
            {
                _logger.LogDebug("Disable operation failed.");
                return BadRequest();
            }
        }

    }
}
