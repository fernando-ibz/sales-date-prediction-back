using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.DTOs;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
        {
            IEnumerable<Product> items = await productService.GetAllAsync();
            IEnumerable<ProductResponseDto> result = mapper.Map<IEnumerable<ProductResponseDto>>(items);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetById(int id)
        {
            Product? item = await productService.GetByIdAsync(id);
            if (item == null) return NotFound();

            ProductResponseDto result = mapper.Map<ProductResponseDto>(item);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            Product item = mapper.Map<Product>(dto);
            await productService.AddAsync(item);
            ProductResponseDto result = mapper.Map<ProductResponseDto>(item);
            return CreatedAtAction(nameof(GetById), new { id = item.ProductId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            if (id != dto.ProductId) return BadRequest();

            Product item = mapper.Map<Product>(dto);
            await productService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? item = await productService.GetByIdAsync(id);
            if (item == null) return NotFound();

            await productService.DeleteAsync(item);
            return NoContent();
        }
    }
}
