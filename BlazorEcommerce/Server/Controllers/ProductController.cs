using BlazorEcommerce.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> Get()
        {
            var results = await _productservice.GetProductAsync();
            return Ok(results);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> Get(int productid)
        {
            var results = await _productservice.GetProductAsync(productid);
            return Ok(results);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var results = await _productservice.GetProductByCategory(categoryUrl);
            return Ok(results);
        }
        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page)
        {
            var results = await _productservice.SearchProducts(searchText, page);
            return Ok(results);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductSearchSuggestions(string searchText)
        {
            var results = await _productservice.GetProductSearchSuggestions(searchText);
            return Ok(results);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetFeaturedProducts()
        {
            var results = await _productservice.GetFeaturedProducts();
            return Ok(results);
        }

    }
}
