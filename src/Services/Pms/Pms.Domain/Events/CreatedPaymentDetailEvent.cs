using Core.EventBus.Events;
using Newtonsoft.Json;

namespace Pms.Domain.Events;

public class CreatedPaymentDetailEvent : DomainEvent
{
    public CreatedPaymentDetailEvent(string amount, string source, string destination)
    {
        Value = JsonConvert.SerializeObject(new { amount, source, destination });

    }
}