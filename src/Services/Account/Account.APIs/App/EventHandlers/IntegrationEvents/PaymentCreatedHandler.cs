using Core.EventBus.Handlers;
using Core.EventBus.Masstransit;
using MassTransit;
using Newtonsoft.Json;
using SharedModels.PaymentEvents;

namespace Account.APIs.App.EventHandlers.IntegrationEvents
{
    //public class PaymentCreatedHandler : IIntegrationEventHandler<PaymentCreated>
    //{
    //    public Task Handle(PaymentCreated evt)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class PaymentCreatedHandler : IConsumer<PaymentCreated>
    {
        public Task Consume(ConsumeContext<PaymentCreated> context)
        {
            throw new NotImplementedException();
        }

        //public Task Handle(PaymentCreated evt)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
