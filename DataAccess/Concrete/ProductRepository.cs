using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product, ProductCatalogContext>,
    IProductRepository
    {
        public ProductRepository(ProductCatalogContext context) : base(context)
        {
        }
    }
}