namespace Pms.APIs.App.Core.Models
{
    public class PaymentDto
    {
        public string DistinationName { get; set; }
        public string SourceName { get; set; }
        public decimal Price { get; set; }
    }
}
