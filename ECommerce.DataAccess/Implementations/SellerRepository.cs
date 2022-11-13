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
    public class SellerRepository : ISellerRepository
    {
        private readonly SellerDbContext _context;

        public SellerRepository(SellerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSeller(Sellers seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return seller.SellerId;
        }

        public async Task<List<Sellers>> GetAllSellersAsync()
        {
            var records = await _context.Sellers.ToListAsync();
            return records;
        }

        public async Task UpdateSellersAsync(int SellerId, Sellers seller)
        {
            _context.Sellers.Update(seller);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSellerAsync(int id)
        {
            var seller = new Sellers() { SellerId = id };

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
        }
    }
}
