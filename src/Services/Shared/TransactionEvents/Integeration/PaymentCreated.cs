using Core.EventBus.Events;

namespace SharedModels.TransactionEvents.Integeration;

public class PaymentCreated : IntegrationEvent
{
    public Guid ClientId { get; }
    public string TransactionId { get; }
    public string PaymentType { get; }
    public string Source { get; }
    public string Destination { get; }

    public PaymentCreated(Guid clientId, string transactionId, string paymentType, string source, string destination)
        : base(clientId)
    {
        ClientId = clientId;
        TransactionId = transactionId;
        PaymentType = paymentType;
        Source = source;
        Destination = destination;
    }
}