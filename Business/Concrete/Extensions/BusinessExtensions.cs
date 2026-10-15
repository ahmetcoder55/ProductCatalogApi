using Business.Abstract;
using Business.Abstract.UnitOfWorks;
using Business.Concrete.Mappings;
using Business.Concrete.Services;
using Business.Concrete.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete.Extensions
{
    public static class BusinessExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddMaps(typeof(MappingProfile));
            });

            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService,ProductService>();

            services.AddScoped<IServiceManager,ServiceManager>();
        }
    }
}