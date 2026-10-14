using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ProductCatalogContext:DbContext
    {
        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> dbContextOptions)
        :base(dbContextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        
    }
}