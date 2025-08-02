namespace Sales.Domain.DTOs
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShipperId { get; set; }
        public string? ShipAddress { get; set; }
    }
}
