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
    public class SellersController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;

        public SellersController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSellersAsync([FromBody] Sellers seller)
        {
            seller.CreatedDate = DateTime.Now;
            await _sellerRepository.CreateSeller(seller);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSellers()
        {
            var sellers = await _sellerRepository.GetAllSellersAsync();
            return Ok(sellers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeller([FromBody] Sellers seller, [FromRoute] int id)
        {
            seller.UpdatedDate = DateTime.Now;
            await _sellerRepository.UpdateSellersAsync(id, seller);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _sellerRepository.DeleteSellerAsync(id);
            return Ok();
        }
    }
}
