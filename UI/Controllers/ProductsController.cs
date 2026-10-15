using Business.Abstract;
using Business.Abstract.UnitOfWorks;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _manager.ProductService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _manager.ProductService.GetByIdAsync(id);
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            await _manager.ProductService.AddAsync(productCreateDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/products
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateDto productUpdateDto)
        {
            await _manager.ProductService.Update(productUpdateDto);
            return NoContent(); // 204 Başarılı ama içerik dönmüyor
        }

        // DELETE: api/products/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.ProductService.Remove(id);
            return NoContent();
        }
    }
}