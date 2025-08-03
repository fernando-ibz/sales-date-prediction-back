namespace Sales.Domain.DTOs
{
    public class EmployeeResponseDto
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Title { get; set; }
    }
}