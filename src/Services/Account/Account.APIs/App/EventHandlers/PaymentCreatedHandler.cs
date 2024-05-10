using Core.EventBus.Masstransit;
using MassTransit;
using Newtonsoft.Json;
using SharedModels.PaymentEvents;

namespace Account.APIs.App.EventHandlers
{
    public class PaymentCreatedHandler : IEventHandler<PaymentCreated>
    {
        public Task Handle(PaymentCreated evt)
        {
            throw new NotImplementedException();
        }
    }
}
