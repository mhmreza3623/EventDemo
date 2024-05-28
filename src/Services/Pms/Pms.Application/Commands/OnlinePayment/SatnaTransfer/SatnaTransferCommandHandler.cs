using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.SatnaTransfer;

/// <summary>
/// انتقال ساتنا
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
public class SatnaTransferCommandHandler : IRequestHandler<SatnaTransferCommand, SatnaTransferCommandResponse>
{

    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public SatnaTransferCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<SatnaTransferCommandResponse> Handle(SatnaTransferCommand command, CancellationToken cancellationToken)
    {

        var requestModel = _mapper.Map<SatnaTransferRequestModel>(command);
        var karizUsername = command.ProviderUsername;


        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.SatnaTransfer, command.Account, command.ProviderPassword);
        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.SatnaTransfer(requestModel);

        return new SatnaTransferCommandResponse(true, karizResponse);
    }
}