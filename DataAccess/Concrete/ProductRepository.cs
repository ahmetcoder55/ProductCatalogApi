using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.Context;

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