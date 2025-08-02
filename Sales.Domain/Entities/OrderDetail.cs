namespace Sales.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Qty { get; set; }
        public decimal Discount { get; set; }

        public Product Product { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}