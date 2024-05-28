using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.LedgerCredit;

/// <summary>
/// بستانکار شدن حساب دفترکل
/// </summary>
/// <param name="ledgerCreditVm"></param>
/// <returns></returns>
public class LedgerCreditCommandHandler : IRequestHandler<LedgerCreditCommand, LedgerCreditCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public LedgerCreditCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<LedgerCreditCommandResponse> Handle(LedgerCreditCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<LedgerCreditRequestModel>(command);
        var karizUsername = command.ProviderUsername;

        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.LedgerCredit, $"{command.AccountNumber};{command.CreditAmount}", command.ProviderPassword);

        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.LedgerCredit(requestModel);

        return new LedgerCreditCommandResponse(true, karizResponse);
    }
}