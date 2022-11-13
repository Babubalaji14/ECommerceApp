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
            var sellers = new Sellers()
            {
                SellerId = seller.SellerId,
                SellerName = seller.SellerName,
                Products = seller.Products,
                WalletBalance = seller.WalletBalance,
                Revenue = seller.Revenue,
                Rating = seller.Rating,
                UpdatedDate = seller.UpdatedDate
            };

            _context.Sellers.Update(sellers);
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
