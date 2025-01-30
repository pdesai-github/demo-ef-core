using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class EShopDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EShopDBContext(DbContextOptions<EShopDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Grocery" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 500, CategoryId = 1 },
                new Product { Id = 2, Name = "T-Shirt", Price = 10, CategoryId = 2 },
                new Product { Id = 3, Name = "Rice", Price = 5, CategoryId = 3 }
            );
        }
    }
}
