using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.Interfaces
{
    public interface ICustomerRepository 
    {
        Customers CreateCustomers(Customers customers);
        Task<List<Customers>> GetAllCustomersAsync();
        Task<Customers> GetCustomersByIdAsync(int CustomerId);
        Task UpdateCustomersAsync(int CustomerId, Customers customers);
        Task DeleteCustomersAsync(int id);
    }
}
