using Core.EventBus.Events;
using Pms.Domain.Entities;

namespace Pms.Domain.DomainEvents;

public class UpdateKarizCredentialClientEvent : DomainEvent
{
    public UpdateKarizCredentialClientEvent(Client client) : base(client)
    {

    }
}