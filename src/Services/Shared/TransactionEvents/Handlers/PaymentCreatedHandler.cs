using MassTransit;
using SharedModels.TransactionEvents.Integeration;

namespace SharedModels.TransactionEvents.Handlers
{
    public class PaymentCreatedHandler : IConsumer<PaymentCreated>
    {
        public Task Consume(ConsumeContext<PaymentCreated> context)
        {
            throw new NotImplementedException();
        }

        //public Task Handle(TransactionCreated evt)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
