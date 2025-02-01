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

        public ProductsController(IProductRepository productsRepository, ILogger<ProductsController> logger)
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

        [HttpGet("{categoryid}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryId(int categoryid)
        {
            try
            {
                var products = await _productsRepository.GetProductsByCatIdAsync(categoryid);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while fetching Products by CategoryId");
                return StatusCode(500, "An error occured while fetching Products by CategoryId");
            }
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Product>>> SearchProducts(string searchText)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = await _productsRepository.SearchProduct(searchText);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while searching Products");
                return StatusCode(500, "An error occured while searching Products");
            }
        }

        [HttpGet("find/{productid}")]
        public async Task<ActionResult<Product>> Find(int productid)
        {
            try
            {
                var product = await _productsRepository.FindProduct(productid);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while finding Product");
                return StatusCode(500, "An error occured while finding Product");
            }
        }

        [HttpGet("getpaginatedproducts")]
        public async Task<ActionResult<List<Product>>> GetPaginatedProducts([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            int skip = (pageNumber - 1) * pageSize;
            try
            {
                var products = await _productsRepository.GetPaginatedProdcucts(skip, pageSize);
                return Ok(products);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting paginated Products");
                return StatusCode(500, "An error occured while getting paginated Products");
            }

        }

        [HttpGet("sortbycatandname")]
        public async Task<ActionResult<List<Product>>> GetProductsSortByCategoryAndName()
        {
            try
            {
                var products = await _productsRepository.GetProductsSortByCategoryAndName();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while GetProductsSortByCategoryAndName");
                return StatusCode(500, "An error occured while GetProductsSortByCategoryAndName");
            }
        }

        [HttpGet("gethighestpriceincat/{categoryId}")]
        public async Task<ActionResult<Product>> GetHighestPriceProductByCategory(int categoryId)
        {
            try
            {
                Product? product = await _productsRepository.GetHighestPriceProductInCategory(categoryId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while gethighestpriceincat");
                return StatusCode(500, "An error occured while gethighestpriceincat");
            }
        }


    }
}
