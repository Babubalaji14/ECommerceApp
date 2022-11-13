using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerceApp.DataAccess  
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
    }
}
