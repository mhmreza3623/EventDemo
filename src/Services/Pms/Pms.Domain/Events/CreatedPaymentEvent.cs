using Core.EventBus.Events;

namespace Pms.Domain.DomainEvents;

public class CreatedPaymentEvent : DomainEvent
{
    public CreatedPaymentEvent(object entity) : base(entity)
    {
    }
}