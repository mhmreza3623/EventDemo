using Core.EventBus.Events;

namespace SharedModels.PaymentEvents
{
    public class PaymentCreated : IntegrationEvent
    {
        public PaymentCreated(Guid tenantID, string source, string Distination, decimal price) : base(tenantID)
        {
            TenantID = tenantID;
            Source = source;
            this.Distination = Distination;
            Price = price;
        }

        public Guid TenantID { get; }
        public string Source { get; }
        public string Distination { get; }
        public decimal Price { get; }
    }
}
