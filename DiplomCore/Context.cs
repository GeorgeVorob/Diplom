using Microsoft.EntityFrameworkCore;
using DiplomCore.Models;
using DiplomCore.Models.CategoriesModels;

namespace DiplomCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        private readonly string _connectionString;

        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<CPU> CPUs { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageContent> ImageContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<GraphicsCard>().ToTable("GraphicsCard");
            modelBuilder.Entity<CPU>().ToTable("CPU");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderedProduct>().ToTable("OrderedProduct");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<ImageContent>().ToTable("ImageContent");

            modelBuilder.Entity<OrderedProduct>().HasKey(c => new { c.OrderID, c.ProductID });
            //modelBuilder.Entity<Image>().HasKey(c => new {c.ImageID, c.ProductID});
        }
    }
}
