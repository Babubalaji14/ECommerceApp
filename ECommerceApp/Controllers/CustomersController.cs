﻿using ECommerceApp.DataAccess.Implementations;
using ECommerceApp.DataAccess.Interfaces;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCustomersAsync([FromBody] Customers customers)
        {
            customers.CreatedDate = DateTime.Now;
            customers.LastOrder = DateTime.Now;
            await _customerRepository.CreateCustomers(customers);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var products = await _customerRepository.GetAllCustomersAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var customers = await _customerRepository.GetCustomersByIdAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Customers customers, [FromRoute] int id)
        {
            customers.UpdatedDate = DateTime.Now;
            customers.LastOrder = DateTime.Now;
            await _customerRepository.UpdateCustomersAsync(id, customers);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerRepository.DeleteCustomersAsync(id);
            return Ok();
        }
    }
}
