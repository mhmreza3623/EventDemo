using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.AccountTransfer;

public class AccountTransferCommandHandler : IRequestHandler<AccountTransferCommand, AccountTransferCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public AccountTransferCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }
    public async Task<AccountTransferCommandResponse> Handle(AccountTransferCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<AccountTransferRequestModel>(command);
        var karizUsername = command.ProviderUsername;
        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.AccountTransfer, command.AccountNumber, command.ProviderPassword);


        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.AccountTransfer(requestModel);

        return new AccountTransferCommandResponse(true, karizResponse);

    }
}