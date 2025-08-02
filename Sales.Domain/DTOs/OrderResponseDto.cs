namespace Sales.Domain.DTOs
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public int? ShipperId { get; set; }
        public string? ShipCity { get; set; }
    }
}
