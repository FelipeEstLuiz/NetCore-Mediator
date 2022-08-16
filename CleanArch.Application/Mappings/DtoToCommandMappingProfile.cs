using AutoMapper;
using CleanArch.Application.Categories.Commands;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;

namespace CleanArch.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDto, ProductCreateCommand>();
            CreateMap<ProductDto, ProductUpdateCommand>();

            CreateMap<CategoryDto, CategoryCreateCommand>();
            CreateMap<CategoryDto, CategoryUpdateCommand>();
        }
    }
}
