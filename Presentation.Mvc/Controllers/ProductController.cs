using System.Text;
using System.Text.Json;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Mvc.Controllers
{
    public class ProductController:Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<IEnumerable<ProductDto>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(products);
            }
            return View(new List<ProductDto>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(productCreateDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(productCreateDto);
        }

        // GET: /Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"products/{id}");
            return RedirectToAction("Index");
        }
    }
}