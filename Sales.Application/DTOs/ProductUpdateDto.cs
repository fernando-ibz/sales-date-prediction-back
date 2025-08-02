using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs
{
    public class ProductUpdateDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }
    }
}

