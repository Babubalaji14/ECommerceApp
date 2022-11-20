using ECommerceApp.DataAccess.Interfaces;
using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Test
{
    public class CustomersRepositoryFake : ICustomerRepository
    {
        private readonly List<Customers> _customers;

        public CustomersRepositoryFake()
        {
            _customers = new List<Customers>()
            { 
                new Customers() { CustomerId = 1, CustomerName = "Matheen" , PhoneNumber = "7993177045" ,
                    Balance = 4254.65, Orders = 41, LastOrder = DateTime.Now, Status = "Active", 
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now

                },
                new Customers() { CustomerId = 2, CustomerName = "Jagga" , PhoneNumber = "7659801069" ,
                    Balance = 53264.43, Orders = 53, LastOrder = DateTime.Now, Status = "Active",
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now

                },
            };
        }

        public Task<List<Customers>> GetAllCustomersAsync()
        {
            return Task.Run(() => _customers);
        }

        public Task<int> CreateCustomers(Customers customers)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customers> GetCustomersByIdAsync(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomersAsync(int CustomerId, Customers customers)
        {
            throw new NotImplementedException();
        }
    }
}
