using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Title { get; set; }
    }
}
