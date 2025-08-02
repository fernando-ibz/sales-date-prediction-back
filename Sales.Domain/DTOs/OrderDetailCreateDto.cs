namespace Sales.Domain.DTOs
{
    public class OrderDetailCreateDto
    {
        public required int ProductId { get; set; }
        public required decimal UnitPrice { get; set; }
        public required short Qty { get; set; }
        public decimal Discount { get; set; } = 0;
    }
}
