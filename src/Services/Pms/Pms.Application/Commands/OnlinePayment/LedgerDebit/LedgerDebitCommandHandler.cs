using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.LedgerDebit;

/// <summary>
/// بدهکار شدن حساب دفتر کل
/// </summary>
/// <param name="ledgerDebitVm"></param>
/// <returns></returns>
public class LedgerDebitCommandHandler : IRequestHandler<LedgerDebitCommand, LedgerDebitCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public LedgerDebitCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<LedgerDebitCommandResponse> Handle(LedgerDebitCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<LedgerDebitRequestModel>(command);
        var karizUsername = command.ProviderUsername;


        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.LedgerDebit, $"{command.AccountNumber} ; {command.DebitAmount}", command.ProviderPassword);

        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.LedgerDebit(requestModel);

        return new LedgerDebitCommandResponse(true, karizResponse);
    }
}