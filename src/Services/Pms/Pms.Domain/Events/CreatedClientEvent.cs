using Core.EventBus.Events;
using Newtonsoft.Json;

namespace Pms.Domain.Events;

public class CreatedClientEvent : DomainEvent
{
    public string ClientName { get; }
    public string UxId { get; }

    public CreatedClientEvent(string clientName, string uxId)
    {
        ClientName = clientName;
        UxId = uxId;

        Value = JsonConvert.SerializeObject(new { ClientName, uxId });
    }
}