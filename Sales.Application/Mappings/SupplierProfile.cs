using AutoMapper;
using Sales.Application.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierResponseDto>();
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<SupplierUpdateDto, Supplier>();
        }
    }
}
