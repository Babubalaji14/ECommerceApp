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
        public void GetAllCustomers_WhenCalled_ReturnsAllCustomers()
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

        [Fact]
        public void GetById_ReturnsOkResult()
        {
            //Arrange  
            var postId = 2;

            //Act  
            var data = _controller.GetCustomerById(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);


        }

        [Fact]
        public void GetById_ReturnsRightItem()
        {

            // Act
            var okResult = _controller.GetCustomerById(2);

            // Assert
            var item = okResult.Result as OkObjectResult;
            Assert.IsType<Customers>(item.Value);

            var bookitem = item.Value as Customers;
            Assert.Equal(2, bookitem.CustomerId);
        }

        [Fact]
        public void CreateCustomer_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            Customers MissingItem = new()
            {
                CustomerId = 3,
                CustomerName = "Matheen",
                PhoneNumber = "7993177045",
                Balance = 4254.65,
                Orders = 41,
                LastOrder = DateTime.Now,
                Status = "Active",
                CreatedDate = DateTime.Now
            };
            _controller.ModelState.AddModelError("CreatedDate", "Required");

            // Act
            var badResponse = _controller.AddCustomersAsync(MissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void AddEmployee_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Customers testItem = new()
            {
                CustomerId = 3,
                CustomerName = "Matheen",
                PhoneNumber = "7993177045",
                Balance = 4254.65,
                Orders = 41,
                LastOrder = DateTime.Now,
                Status = "Active",
                CreatedDate = DateTime.Now
            };

            // Act
            var createdResponse = _controller.AddCustomersAsync(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void AddEmployee_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Customers()
            {
                CustomerId = 3,
                CustomerName = "Matheen",
                PhoneNumber = "7993177045",
                Balance = 4254.65,
                Orders = 41,
                LastOrder = DateTime.Now,
                Status = "Active",
                CreatedDate = DateTime.Now
            };

            // Act
            var createdResponse = _controller.AddCustomersAsync(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Customers;

            // Assert
            Assert.IsType<Customers>(item);
            Assert.Equal("Matheen", item.CustomerName);
        }
    }
}
