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
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrders(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();
            return orders.OrderId;

        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            var records = await _context.Orders.ToListAsync();
            return records;
        }

        public async Task<Orders> GetOrdersByIdAsync(int OrdersId) 
        {
            var records = await _context.Orders.Where(x => x.OrderId == OrdersId).FirstOrDefaultAsync();
            return records;
        }


        public async Task UpdateOrdersAsync(int OrderId, Orders orders)
        {
            var order = new Orders()
            {
                OrderId = orders.OrderId,
                BillingName = orders.BillingName,
                Date = orders.Date,
                PaymentStatus = orders.PaymentStatus,
                Total = orders.Total,
                PaymentMethod = orders.PaymentMethod,
                OrderStatus = orders.OrderStatus,
                UpdatedDate = orders.UpdatedDate
            };

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrdersAsync(int id) 
        {
            var order = new Orders() { OrderId = id };

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}
