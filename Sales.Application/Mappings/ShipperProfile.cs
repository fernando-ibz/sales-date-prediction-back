using AutoMapper;
using Sales.Application.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings
{
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperResponseDto>();
            CreateMap<ShipperCreateDto, Shipper>();
            CreateMap<ShipperUpdateDto, Shipper>();
            CreateMap<Shipper, ShipperUpdateDto>();
        }
    }
}
