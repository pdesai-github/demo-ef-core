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

    }
}
