using SharedKernel.Common.MongoDb;

namespace Pms.Domain.Entities.Mongo
{
    public class PaymentLogCollection : MongoBaseEntity
    {
        public decimal Amount { get; set; }
        public string SourceAccount { get; set; }
        public string DistinationAccount { get; set; }
    }
}
