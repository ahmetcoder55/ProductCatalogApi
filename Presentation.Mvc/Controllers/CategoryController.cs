using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace Presentation.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }

        // GET: /Category/Index
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("category");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(categories);
            }
            return View(new List<CategoryDto>());
        }

        // GET: /Category/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(categoryCreateDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("category", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(categoryCreateDto);
        }

        // GET: /Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"category/{id}");
            return RedirectToAction("Index");
        }
    }
}