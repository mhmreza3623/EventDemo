using Core.EventBus.Handlers;
using Core.EventBus.Masstransit;
using MassTransit;
using Newtonsoft.Json;
using SharedModels.TransactionEvents.Integeration;

namespace Account.APIs.App.EventHandlers.IntegrationEvents
{
    public class PaymentCreatedHandler : IIntegrationEventHandler<TransactionCreated>
    {
        public Task Handle(TransactionCreated evt)
        {
            throw new NotImplementedException();
        }
    }

    //public class PaymentCreatedHandler : IConsumer<TransactionCreated>
    //{
    //    public Task Consume(ConsumeContext<TransactionCreated> context)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public Task Handle(TransactionCreated evt)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}
}
