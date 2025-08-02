using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(ICustomerService customerService, IOrderService orderService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDto>>> GetAll()
        {
            IEnumerable<Customer> customers = await customerService.GetAllAsync();
            IEnumerable<CustomerResponseDto> result = mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
            IEnumerable<OrderNextPredictedDto> orders = await orderService.GetAllOrderNextPredictedAsync();

            foreach (CustomerResponseDto customer in result)
            {
                OrderNextPredictedDto? order = orders.FirstOrDefault(o => o.CustId == customer.CustId);

                if (order == null) 
                    continue;

                customer.LastOrderDate = order.OrderDate;
                customer.NextPredictedOrder = order.NextPredictedOrder;
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetById(int id)
        {
            Customer? customer = await customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();

            CustomerResponseDto result = mapper.Map<CustomerResponseDto>(customer);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto dto)
        {
            Customer customer = mapper.Map<Customer>(dto);
            await customerService.AddAsync(customer);
            CustomerResponseDto result = mapper.Map<CustomerResponseDto>(customer);
            return CreatedAtAction(nameof(GetById), new { id = result.CustId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerUpdateDto dto)
        {
            if (id != dto.CustId) return BadRequest();

            Customer customer = mapper.Map<Customer>(dto);
            await customerService.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer? customer = await customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();

            await customerService.DeleteAsync(customer);
            return NoContent();
        }
    }
}
