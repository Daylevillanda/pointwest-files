using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Demo1a.Models;

namespace EntityFramework.Demo1a.Data
{
    public class OnlineShopContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<ProductOrder> ProductOders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-T6QKE2L;Database=OnlineShop;User Id=sa;Password=p@ssw0rd");
            }
        }
    }
}
