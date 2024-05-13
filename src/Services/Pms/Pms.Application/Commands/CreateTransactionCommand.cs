using MediatR;
using Pms.Domain.Enums;

namespace Pms.Application.Commands
{
    public class CreateTransactionCommand : IRequest<BaseResponse>
    {
        public string Source { get; }
        public string Destination { get; }
        public decimal Amount { get; }

        public CreateTransactionCommand(string source, string destination, decimal amount)
        {
            Source = source;
            Destination = destination;
            Amount = amount;
        }
    }
}
