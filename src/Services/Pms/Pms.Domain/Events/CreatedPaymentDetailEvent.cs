using Core.EventBus.Events;

namespace Pms.Domain.DomainEvents;

public class CreatedPaymentDetailEvent : DomainEvent
{
    public CreatedPaymentDetailEvent(object entity) : base(entity)
    {
    }
}