using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diplom.Models;
using Diplom.Models.CategoriesModels;

namespace Diplom.DbData
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<CPU> CPUs { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<GraphicsCard>().ToTable("GraphicsCard");
            modelBuilder.Entity<CPU>().ToTable("CPU");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderedProduct>().ToTable("OrderedProduct");

            modelBuilder.Entity<OrderedProduct>().HasKey(c => new { c.OrderID, c.ProductID });
        }
    }
}
