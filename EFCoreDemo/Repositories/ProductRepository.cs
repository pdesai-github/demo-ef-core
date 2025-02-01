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
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCatIdAsync(int categoryId)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> SearchProduct(string searchText)
        {
            var products = await _context.Products
                .Where(p=>p.Name.Contains(searchText))
                .ToListAsync();

            return products;
        }

        public async Task<Product?> FindProduct(int productid)
        {
            Product? product = await _context.Products.FindAsync(productid);
            return product;
        }

        public async Task<List<Product>> GetPaginatedProdcucts(int skip, int take)
        {
            var products = await _context.Products
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsSortByCategoryAndName()
        {
            var products = await _context.Products
                .OrderBy(p=> p.CategoryId)
                .ThenBy(p=>p.Name)
                .ToListAsync();

            return products;
        }

        public async Task<Product?> GetHighestPriceProductInCategory(int categoryId)
        {
            Product? product = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(p => p.Price)
                .FirstOrDefaultAsync();

            return product;
        }

    }
}
