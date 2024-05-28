using Core.EventBus.Events;
using Newtonsoft.Json;

namespace Pms.Domain.Events;

public class UpdateDpkCredentialClientEvent : DomainEvent
{
    public UpdateDpkCredentialClientEvent(string uxId,string dpkUsername)
    {
        Value = JsonConvert.SerializeObject(new { uxId, dpkUsername });

    }
}