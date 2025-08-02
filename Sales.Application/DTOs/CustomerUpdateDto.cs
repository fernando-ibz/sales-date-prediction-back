using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs
{
    public class CustomerUpdateDto
    {
        [Required]
        public int CustId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; } = null!;

        [MaxLength(100)]
        public string? ContactName { get; set; }

        [MaxLength(50)]
        public string? ContactTitle { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(50)]
        public string? Region { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(30)]
        public string? Phone { get; set; }

        [MaxLength(30)]
        public string? Fax { get; set; }
    }
}
