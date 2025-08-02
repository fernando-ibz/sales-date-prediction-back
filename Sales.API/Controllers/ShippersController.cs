using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippersController(IShipperService shipperService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipperResponseDto>>> GetAll()
        {
            IEnumerable<Shipper> items = await shipperService.GetAllAsync();
            IEnumerable<ShipperResponseDto> result = mapper.Map<IEnumerable<ShipperResponseDto>>(items);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipperResponseDto>> GetById(int id)
        {
            Shipper? item = await shipperService.GetByIdAsync(id);
            if (item == null) return NotFound();

            ShipperResponseDto result = mapper.Map<ShipperResponseDto>(item);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipperCreateDto dto)
        {
            Shipper item = mapper.Map<Shipper>(dto);
            await shipperService.AddAsync(item);
            ShipperResponseDto result = mapper.Map<ShipperResponseDto>(item);
            return CreatedAtAction(nameof(GetById), new { id = item.ShipperId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ShipperUpdateDto dto)
        {
            if (id != dto.ShipperId) return BadRequest();

            Shipper item = mapper.Map<Shipper>(dto);
            await shipperService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Shipper? item = await shipperService.GetByIdAsync(id);
            if (item == null) return NotFound();

            await shipperService.DeleteAsync(item);
            return NoContent();
        }
    }
}
