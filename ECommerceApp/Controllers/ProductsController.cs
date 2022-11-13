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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProductsAsync([FromBody] Products products)
        {
            products.CreatedDate = DateTime.Now;
            products.AddedDate = DateTime.Now;
            await _productRepository.CreateProduct(products);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productRepository.GetProductsByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Products products, [FromRoute] int id)
        {
            products.UpdatedDate = DateTime.Now;
            products.AddedDate = DateTime.Now;
            await _productRepository.UpdateProductAsync(id, products);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}
