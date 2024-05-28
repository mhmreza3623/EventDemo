using Core.EventBus.Events;
using Newtonsoft.Json;

namespace Pms.Domain.Events;

public class UpdateProviderCredentialClientEvent : DomainEvent
{
    public UpdateProviderCredentialClientEvent(string uxId,string username)
    {
        Value = JsonConvert.SerializeObject(new { uxId, username });

    }
}