using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<int> CreateProduct(Products products);
        Task<List<Products>> GetAllProductsAsync();

        Task<Products> GetProductsByIdAsync(int ProductId);
        Task UpdateProductAsync(int ProductId, Products products);
        Task DeleteProductAsync(int id);
    }
}
