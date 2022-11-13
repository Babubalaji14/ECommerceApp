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
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartsController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSellersAsync([FromBody] ShoppingCart shoppingCart)
        {
            shoppingCart.CreatedDate = DateTime.Now;
            await _shoppingCartRepository.CreateSellers(shoppingCart);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSellers()
        {
            var shoppingCart = await _shoppingCartRepository.GetAllSellersAsync();
            return Ok(shoppingCart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeller([FromBody] ShoppingCart shoppingCart, [FromRoute] int id)
        {
            shoppingCart.UpdatedDate = DateTime.Now;
            await _shoppingCartRepository.UpdateSellersAsync(id, shoppingCart);
            return Ok();
        }
    }
}
