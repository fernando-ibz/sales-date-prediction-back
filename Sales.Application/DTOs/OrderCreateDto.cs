using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs
{
    public class OrderCreateDto
    {
        [Required]
        public DateTime OrderDate { get; set; }

        public int? EmployeeId { get; set; }

        public int? ShipperId { get; set; }

        public string? ShipAddress { get; set; }
    }
}