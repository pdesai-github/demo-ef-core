using EFCoreDemo.Models;

namespace EFCoreDemo.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
    }
}
