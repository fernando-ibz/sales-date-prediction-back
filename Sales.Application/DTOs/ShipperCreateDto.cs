using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs
{
    public class ShipperCreateDto
    {
        [Required]
        public string CompanyName { get; set; } = null!;

        public string? Phone { get; set; }
    }
}
