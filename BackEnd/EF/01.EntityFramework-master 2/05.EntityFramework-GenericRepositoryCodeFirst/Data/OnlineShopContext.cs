using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo;

#nullable disable

namespace EntityFrameworkDemo.Data
{
    public partial class OnlineShopContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationHelper.GetInstance().GetProperty<string>("DbConnectionString"));
            }
        }
    }
}
