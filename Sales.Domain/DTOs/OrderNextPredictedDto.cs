namespace Sales.Domain.DTOs
{
    public class OrderNextPredictedDto
    {
        public int CustId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
