namespace Sales.Domain.DTOs
{
    public class CustomerResponseDto
    {
        public int CustId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        //Todo: fix
        public DateTime? NextPredictedOrder { get; set; } = DateTime.Now;
        public DateTime? LastOrderDate { get; set; } = DateTime.Now;
    }
}
