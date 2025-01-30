using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
       private EShopDBContext _context;

        public ProductRepository(EShopDBContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p=>p.Category)
                .ToListAsync();
        }


    }
}
