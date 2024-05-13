using Core.EventBus.Handlers;
using Core.EventBus.Masstransit;
using MassTransit;
using Newtonsoft.Json;
using SharedModels.TransactionIntegrationEvents;

namespace Account.APIs.App.EventHandlers.IntegrationEvents
{
    public class TransactionCreatedHandler : IConsumer<TransactionCreated>
    {
        public Task Consume(ConsumeContext<TransactionCreated> context)
        {
            return Task.CompletedTask;
        }
    }
}
