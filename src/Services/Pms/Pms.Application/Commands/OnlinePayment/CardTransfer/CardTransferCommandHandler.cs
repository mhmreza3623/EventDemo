using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.CardTransfer;

public class CardTransferCommandHandler : IRequestHandler<CardTransferCommand, CardTransferCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public CardTransferCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<CardTransferCommandResponse> Handle(CardTransferCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<CardTransferRequestModel>(command);
        var karizUsername = command.ProviderUsername;

        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.IsoCardTransfer, $"{command.SrcPan};{command.DstPan};{command.Amount}", command.ProviderPassword);

        requestModel.channel = karizUsername;
        requestModel.hash = hashInfo;

        var karizResponse = await _paymentServiceFactory.CardTransfer(requestModel);

        return new CardTransferCommandResponse(true, karizResponse);
    }
}