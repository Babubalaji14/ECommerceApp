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
    public class CustomerRepository :ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomers(Customers customers) 
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
            return customers.CustomerId;

        }

        public async Task<List<Customers>> GetAllCustomersAsync()
        {
            var records = await _context.Customers.ToListAsync();
            return records;
        }

        public async Task<Customers> GetCustomersByIdAsync(int CustomerId)
        {
            var records = await _context.Customers.Where(x => x.CustomerId == CustomerId).FirstOrDefaultAsync();
            return records;
        }


        public async Task UpdateCustomersAsync(int CustomerId, Customers customers)
        {
            var customer = new Customers()
            {
                CustomerId = customers.CustomerId,
                CustomerName = customers.CustomerName,
                PhoneNumber = customers.PhoneNumber,
                Balance = customers.Balance,
                Orders = customers.Orders,
                LastOrder = customers.LastOrder,
                Status = customers.Status,
                UpdatedDate = customers.UpdatedDate
            };

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomersAsync(int id)
        {
            var customer = new Customers() { CustomerId  = id };

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
        }
    }
}
