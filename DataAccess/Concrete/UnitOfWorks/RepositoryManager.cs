using DataAccess.Abstract;
using DataAccess.Abstract.UnitOfWorks;
using DataAccess.Concrete.Context;

namespace DataAccess.Concrete.UnitOfWorks
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ProductCatalogContext _context;
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(ProductCatalogContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ICategoryRepository Category => _categoryRepository;

        public IProductRepository Product => _productRepository;

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}