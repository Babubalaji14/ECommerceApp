using ECommerceApp.DataAccess.DBContext;
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
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartDbContext _context;

        public ShoppingCartRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSellers(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            await _context.SaveChangesAsync();
            return shoppingCart.ProductId;

        }

        public async Task<List<ShoppingCart>> GetAllSellersAsync()
        {
            var records = await _context.ShoppingCarts.ToListAsync();
            return records;
        }

        public async Task<ShoppingCart> GetSellersByIdAsync(int ProductId)
        {
            var records = await _context.ShoppingCarts.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
            return records;
        }


        public async Task UpdateSellersAsync(int ProductId, ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Update(shoppingCart);
            await _context.SaveChangesAsync();
        }
    }
}
