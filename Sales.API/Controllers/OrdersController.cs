using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService, IOrderDetailService orderDetailService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetAll()
        {
            IEnumerable<Order> items = await orderService.GetAllAsync();
            IEnumerable<OrderResponseDto> result = mapper.Map<IEnumerable<OrderResponseDto>>(items);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDto>> GetById(int id)
        {
            Order? item = await orderService.GetByIdAsync(id);
            if (item == null) return NotFound();

            OrderResponseDto result = mapper.Map<OrderResponseDto>(item);
            return Ok(result);
        }

        [HttpGet("/Customer/{customeId}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetByCustomerId(int customeId)
        {
            IEnumerable<Order> items = await orderService.GetAllbyCustomer(customeId);
            IEnumerable<OrderResponseDto> result = mapper.Map<IEnumerable<OrderResponseDto>>(items);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            Order item = mapper.Map<Order>(dto);
            item.OrderDate = DateTime.UtcNow;
            OrderDetail itemDetail = mapper.Map<OrderDetail>(dto.OrderDetail);
            
            await orderService.AddAsync(item);

            itemDetail.OrderId = item.OrderId;
            await orderDetailService.AddAsync(itemDetail);

            OrderResponseDto result = mapper.Map<OrderResponseDto>(item);
            return CreatedAtAction(nameof(GetById), new { id = item.OrderId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderUpdateDto dto)
        {
            if (id != dto.OrderId) return BadRequest();

            Order item = mapper.Map<Order>(dto);
            await orderService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Order? item = await orderService.GetByIdAsync(id);
            if (item == null) return NotFound();

            await orderService.DeleteAsync(item);
            return NoContent();
        }
    }
}
