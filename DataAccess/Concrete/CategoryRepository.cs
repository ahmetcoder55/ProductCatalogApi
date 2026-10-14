using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category, ProductCatalogContext>, ICategoryRepository
    {
        public CategoryRepository(ProductCatalogContext context) : base(context)
        {
        }
    }
}