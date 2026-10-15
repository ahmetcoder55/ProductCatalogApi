using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(CategoryCreateDto entity);
        Task Update(CategoryUpdateDto entity);
        Task Remove(int id);
    }
}