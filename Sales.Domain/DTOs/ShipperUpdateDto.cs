using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.DTOs
{
    public class ShipperUpdateDto
    {
        [Required]
        public int ShipperId { get; set; }

        [Required]
        public string CompanyName { get; set; } = null!;

        public string? Phone { get; set; }
    }
}

