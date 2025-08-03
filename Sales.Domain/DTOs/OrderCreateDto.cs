namespace Sales.Domain.DTOs
{
    public class OrderCreateDto
    {
        public required int CustId { get; set; }
        public required int EmpId { get; set; }
        public required DateTime OrderDate { get; set; }
        public required DateTime RequiredDate { get; set; }
        public required DateTime ShippedDate { get; set; }
        public required int ShipperId { get; set; }
        public required decimal Freight { get; set; }
        public required string ShipName { get; set; }
        public required string ShipAddress { get; set; }
        public required string ShipCity { get; set; }
        public required string ShipRegion { get; set; }
        public required string ShipPostalCode { get; set; }
        public required string ShipCountry { get; set; }

        public required OrderDetailCreateDto OrderDetail { get; set; }
    }
}