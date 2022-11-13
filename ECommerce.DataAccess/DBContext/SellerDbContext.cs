using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DataAccess.DBContext
{
    public class SellerDbContext : DbContext
    {
        public SellerDbContext(DbContextOptions<SellerDbContext> options)
              : base(options)
        {

        }

        public DbSet<Sellers> Sellers { get; set; }
    }
}
