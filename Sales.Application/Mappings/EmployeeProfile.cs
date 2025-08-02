using AutoMapper;
using Sales.Application.DTOs;
using Sales.Domain.Entities;

namespace Sales.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponseDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
