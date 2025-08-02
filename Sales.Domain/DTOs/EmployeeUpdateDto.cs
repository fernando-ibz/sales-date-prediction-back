using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.DTOs
{
    public class EmployeeUpdateDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Title { get; set; }
    }
}

