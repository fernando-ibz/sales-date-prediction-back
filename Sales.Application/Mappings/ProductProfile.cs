using AutoMapper;
using Sales.Application.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
