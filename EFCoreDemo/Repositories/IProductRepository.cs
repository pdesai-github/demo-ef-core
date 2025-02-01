using EFCoreDemo.Models;

namespace EFCoreDemo.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByCatIdAsync(int categoryId);
        Task<List<Product>> SearchProduct(string searchText);
        Task<Product?> FindProduct(int productid);
        Task<List<Product>> GetPaginatedProdcucts(int skip, int take);
        Task<List<Product>> GetProductsSortByCategoryAndName();
        Task<Product?> GetHighestPriceProductInCategory(int categoryId);
    }
}
