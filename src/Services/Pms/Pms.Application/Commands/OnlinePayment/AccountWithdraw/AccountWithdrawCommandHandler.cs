using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.AccountWithdraw;

/// <summary>
/// برداشت از حساب
/// </summary>
/// <param name="accountVM"></param>
/// <returns></returns>
public class AccountWithdrawCommandHandler : IRequestHandler<AccountWithdrawCommand, AccountWithdrawCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public AccountWithdrawCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<AccountWithdrawCommandResponse> Handle(AccountWithdrawCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<AccountWithdrawRequestModel>(command);
        var karizUsername = command.ProviderUsername;

        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.AccountWithdraw, $"{command.AccountNumber};{command.Amount}", command.ProviderPassword);
        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.AccountWithdraw(requestModel);

        return new AccountWithdrawCommandResponse(true, karizResponse);

    }
}

