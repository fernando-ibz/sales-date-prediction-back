using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.DTOs
{
    public class ShipperCreateDto
    {
        [Required]
        public string CompanyName { get; set; } = null!;

        public string? Phone { get; set; }
    }
}
