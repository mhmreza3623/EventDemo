using Account.APIs.App.Events;
using MassTransit;

namespace Account.APIs.App.DomainEvents
{
    public class AccountCreatedHandler : IConsumer<AccountCreated>
    {
        public Task Consume(ConsumeContext<AccountCreated> context)
        {
            throw new NotImplementedException();
        }
    }
}
