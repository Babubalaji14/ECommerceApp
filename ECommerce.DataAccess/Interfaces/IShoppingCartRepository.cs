using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<int> CreateSellers(ShoppingCart shoppingCart);
        Task<List<ShoppingCart>> GetAllSellersAsync();
        Task<ShoppingCart> GetSellersByIdAsync(int ProductId);
        Task UpdateSellersAsync(int ProductId, ShoppingCart shoppingCart);
    }
}
