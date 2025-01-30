using EFCoreDemo.Models;
using EFCoreDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productsRepository;
        private ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productsRepository,ILogger<ProductsController> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> Get()
        {
            try
            {
                var products = await _productsRepository.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while fetching Products");
                return StatusCode(500, "An error occured while fetching Products");
            }
        }
    }
}
