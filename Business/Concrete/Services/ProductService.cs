using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract.UnitOfWorks;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Concrete.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        // Constructor Injection (Dependency Injection)
        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductCreateDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Eklenecek ürün bilgileri boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(entity.ProductName))
            {
                throw new ArgumentException("Ürün adı boş olamaz.", nameof(entity.ProductName));
            }

            var product = _mapper.Map<Product>(entity);

            await _manager.Product.AddAsync(product);
            await _manager.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _manager.Product.GetAllAsync();

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Geçersiz ürün ID değeri.", nameof(id));
            }

            var product = await _manager.Product.GetByIdAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"ID değeri {id} olan ürün bulunamadı.");
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Geçersiz ürün ID değeri.", nameof(id));
            }

            var product = await _manager.Product.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Silinmek istenen ID ({id}) ile eşleşen ürün bulunamadı.");
            }

            _manager.Product.Remove(product);
            await _manager.SaveChangesAsync();
        }

        public async Task Update(ProductUpdateDto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Güncellenecek ürün bilgileri boş olamaz.");
            }

            var existingProduct = await _manager.Product.GetByIdAsync(entity.ProductId);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Güncellenmek istenen ID ({entity.ProductId}) ile eşleşen ürün bulunamadı.");
            }

            if (string.IsNullOrWhiteSpace(entity.ProductName))
            {
                throw new ArgumentException("Ürün adı boş olamaz.", nameof(entity.ProductName));
            }

            _mapper.Map(entity, existingProduct);

            _manager.Product.Update(existingProduct);
            await _manager.SaveChangesAsync();
        }
    }
}