using Pms.Domain.Common.Enums;
using SharedKernel.Common.SqlModels;

namespace Pms.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public PaymentType Type { get; set; }
        public string RequestToken { get; set; }
        public string ReferenceId { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string MetaData { get; set; }

        public long ClientId { get; set; }
        public ICollection<PaymentDetail> PaymentDetails { get; set; }

    }
}
