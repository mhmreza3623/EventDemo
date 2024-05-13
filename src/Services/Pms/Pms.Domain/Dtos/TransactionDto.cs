namespace Pms.Domain.Dtos
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public string Distination { get; set; }
        public string Source { get; set; }
    }
}
