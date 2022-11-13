using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrders(Orders orders);
        Task<List<Orders>> GetAllOrdersAsync();
        Task<Orders> GetOrdersByIdAsync(int OrdersId);
        Task UpdateOrdersAsync(int OrderId, Orders orders);
        Task DeleteOrdersAsync(int id);
    }
}
