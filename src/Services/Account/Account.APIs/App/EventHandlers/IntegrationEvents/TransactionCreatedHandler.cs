using MassTransit;
using SharedModels;

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
