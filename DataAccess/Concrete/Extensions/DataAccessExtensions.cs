using DataAccess.Abstract;
using DataAccess.Abstract.UnitOfWorks;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.Extensions
{
    public static class DataAccessExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ProductCatalogContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}