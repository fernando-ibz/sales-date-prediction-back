using AutoMapper;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailResponseDto>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();
            CreateMap<OrderDetailUpdateDto, OrderDetail>();
        }
    }
}
