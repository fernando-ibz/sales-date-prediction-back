using AutoMapper;
using Sales.Application.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
