using Ecommerce.Models;
using ECommerce.DatabaseContext.FluentConfiguration;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ECommerce.DatabaseContext
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders { get; set; }


       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(false)
                .UseSqlServer("Server=LAPTOP-GL2B48KC;Database=ECommerce; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().Property(c => c.Name).IsRequired();

            modelBuilder.ApplyConfiguration(new ProductFluentConfiguration());

            modelBuilder.Entity<ProductOrder>()
                .HasKey(c => new { c.ProductId, c.OrderId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(c => c.Product)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(c => c.Order)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.OrderId);
        }
    }

   
}
