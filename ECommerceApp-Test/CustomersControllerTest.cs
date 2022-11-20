using ECommerceApp.Controllers;
using ECommerceApp.DataAccess.Interfaces;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace ECommerceApp_Test
{
    public class CustomersControllerTest 
    {
        private readonly CustomersController _controller;
        private readonly ICustomerRepository _customerRepository;

        public CustomersControllerTest()
        {
            _customerRepository = new CustomersRepositoryFake();
            _controller = new CustomersController(_customerRepository);
        }

        [Fact]
        public void GetAllCustomers_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAllCustomers();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result as OkObjectResult);
        }

        [Fact]
        public void GetAllEmployee_WhenCalled_ReturnsAllEmployess()
        {
            // Act
            var okResult = _controller.GetAllCustomers();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

            var list = okResult.Result as OkObjectResult;
            Assert.IsType<List<Customers>>(list.Value);

            var listEmployee = list.Value as List<Customers>;
            Assert.Equal(2, listEmployee.Count);
        }
    }
}
