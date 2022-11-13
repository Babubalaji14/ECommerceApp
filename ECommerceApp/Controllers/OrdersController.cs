using ECommerceApp.DataAccess.Interfaces;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
         private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddOrdersAsync([FromBody] Orders orders)
        {
            orders.Date = DateTime.Now;
            orders.CreatedDate = DateTime.Now; 
            await _orderRepository.CreateOrders(orders);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllOrders()
        {
            var products = await _orderRepository.GetAllOrdersAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersById([FromRoute] int id)
        {
            var product = await _orderRepository.GetOrdersByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrders([FromBody] Orders orders, [FromRoute] int id)
        {
            orders.Date = DateTime.Now;
            orders.UpdatedDate = DateTime.Now;
            await _orderRepository.UpdateOrdersAsync(id, orders);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders([FromRoute] int id)
        {
            await _orderRepository.DeleteOrdersAsync(id);
            return Ok();
        }
    }
}
