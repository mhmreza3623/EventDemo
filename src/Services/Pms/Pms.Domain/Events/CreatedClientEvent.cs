
using Core.EventBus.Events;
using Pms.Domain.Entities;

namespace Pms.Domain.DomainEvents;

public class CreatedClientEvent : DomainEvent
{
    public CreatedClientEvent(Client client) : base(client)
    {

    }
}