using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Concrete.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category,CategoryUpdateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product,ProductUpdateDto>().ReverseMap();
        }
    }
}