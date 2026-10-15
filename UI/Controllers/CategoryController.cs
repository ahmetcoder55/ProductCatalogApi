using Business.Abstract.UnitOfWorks;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _manager.CategoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET: api/category/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _manager.CategoryService.GetByIdAsync(id);
            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryCreateDto)
        {
            await _manager.CategoryService.AddAsync(categoryCreateDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/category
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            await _manager.CategoryService.Update(categoryUpdateDto);
            return NoContent();
        }

        // DELETE: api/category/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.CategoryService.Remove(id);
            return NoContent();
        }
    }
}