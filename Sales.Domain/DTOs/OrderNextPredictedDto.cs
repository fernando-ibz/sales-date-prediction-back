using Microsoft.EntityFrameworkCore;

namespace Sales.Domain.DTOs
{
    [Keyless]
    public class OrderNextPredictedDto
    {
        public int CustId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
