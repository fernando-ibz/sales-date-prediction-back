namespace Sales.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        public Supplier Supplier { get; set; } = null!;

        public Category Category { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get; set; } = [];
    }
}