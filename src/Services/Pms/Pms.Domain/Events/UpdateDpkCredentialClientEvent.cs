using Core.EventBus.Events;

namespace Pms.Domain.DomainEvents;

public class UpdateDpkCredentialClientEvent : DomainEvent
{
    public UpdateDpkCredentialClientEvent(object entity) : base(entity)
    {
    }
}