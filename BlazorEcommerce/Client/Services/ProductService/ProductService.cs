

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;

        }
        public List<Product> Products { get; set; } = new List<Product>();
        public async Task GetProducts()
        {
            var results = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if (results != null && results.Data != null)
                Products = results.Data;

        }

        public async Task<ServiceResponse<Product>> GetProducts(int productId)
        {
            var results = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return results;
        }
    }
}
