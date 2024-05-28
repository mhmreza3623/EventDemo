using MediatR;

namespace Pms.Application.Commands.OnlinePayment;

public class BaseOnlinePaymentCommand<T> : IRequest<T> where T : class
{
    public string ProviderUsername { get; }
    public string ProviderPassword { get; }
    public string ClientUxId { get; }

}