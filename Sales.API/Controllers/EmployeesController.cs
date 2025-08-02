using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IEmployeeService employeeService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponseDto>>> GetAll()
        {
            IEnumerable<Employee> items = await employeeService.GetAllAsync();
            IEnumerable<EmployeeResponseDto> result = mapper.Map<IEnumerable<EmployeeResponseDto>>(items);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDto>> GetById(int id)
        {
            Employee? item = await employeeService.GetByIdAsync(id);
            if (item == null) return NotFound();

            EmployeeResponseDto result = mapper.Map<EmployeeResponseDto>(item);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDto dto)
        {
            Employee item = mapper.Map<Employee>(dto);
            await employeeService.AddAsync(item);
            EmployeeResponseDto result = mapper.Map<EmployeeResponseDto>(item);
            return CreatedAtAction(nameof(GetById), new { id = item.EmpId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateDto dto)
        {
            if (id != dto.EmployeeId) return BadRequest();

            Employee item = mapper.Map<Employee>(dto);
            await employeeService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Employee? item = await employeeService.GetByIdAsync(id);
            if (item == null) return NotFound();

            await employeeService.DeleteAsync(item);
            return NoContent();
        }
    }
}
