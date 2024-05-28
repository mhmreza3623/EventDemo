using AutoMapper;
using MediatR;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;

namespace Pms.Application.Commands.OnlinePayment.IsoReverseCardTransfer;

public class IsoReverseCardTransferCommandHandler : IRequestHandler<IsoReverseCardTransferCommand, IsoReverseCardTransferCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public IsoReverseCardTransferCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<IsoReverseCardTransferCommandResponse> Handle(IsoReverseCardTransferCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<IsoReverseCardTransferRequestModel>(command);

        var karizResponse = await _paymentServiceFactory.IsoReverseCardTransfer(requestModel);

        return new IsoReverseCardTransferCommandResponse(true, karizResponse);
    }
}