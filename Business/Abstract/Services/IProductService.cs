using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task AddAsync(ProductCreateDto entity);
        Task Update(ProductUpdateDto entity);
        Task Remove(int id);
    } 
}