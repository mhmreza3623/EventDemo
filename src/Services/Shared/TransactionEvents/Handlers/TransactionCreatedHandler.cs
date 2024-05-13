using MassTransit;
using SharedModels.TransactionEvents.Integeration;

namespace SharedModels.TransactionEvents.Handlers
{
    public class TransactionCreatedHandler : IConsumer<TransactionCreated>
    {
        public Task Consume(ConsumeContext<TransactionCreated> context)
        {
            throw new NotImplementedException();
        }

        //public Task Handle(TransactionCreated evt)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
