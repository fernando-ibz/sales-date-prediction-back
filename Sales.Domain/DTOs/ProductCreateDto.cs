using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string ProductName { get; set; } = null!;

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }
    }
}

