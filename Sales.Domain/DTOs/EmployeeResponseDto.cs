namespace Sales.Domain.DTOs
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Title { get; set; }
    }
}