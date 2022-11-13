using ECommerceApp.DataAccess.Interfaces;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProduct(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return products.ProductId;

        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            var records = await _context.Products.ToListAsync();
            return records;
        }

        public async Task<Products> GetProductsByIdAsync(int ProductId)
        {
            var records = await _context.Products.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
            return records;
        }


        public async Task UpdateProductAsync(int ProductId, Products products)
        {
            var product = new Products()
            {
                ProductId = products.ProductId,
                ProductName = products.ProductName,
                Rating = products.Rating,
                Category = products.Category,
                AddedDate = products.AddedDate,
                Price = products.Price,
                Quantity = products.Quantity,
                UpdatedDate = products.UpdatedDate
            };

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var products = new Products() { ProductId = id };

            _context.Products.Remove(products);

            await _context.SaveChangesAsync();
        }
    }
}
