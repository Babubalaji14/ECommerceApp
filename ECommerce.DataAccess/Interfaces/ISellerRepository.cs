using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Interfaces
{
    public interface ISellerRepository
    {
        Task<int> CreateSeller(Sellers seller);
        Task<List<Sellers>> GetAllSellersAsync();
        Task UpdateSellersAsync(int SellerId, Sellers seller);
        Task DeleteSellerAsync(int id);
    }
}
