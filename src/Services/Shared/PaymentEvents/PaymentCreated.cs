using Core.EventBus.Events;

namespace SharedModels.PaymentEvents
{
    public record PaymentCreated(string source, string Distination, decimal price) : Event;
}
