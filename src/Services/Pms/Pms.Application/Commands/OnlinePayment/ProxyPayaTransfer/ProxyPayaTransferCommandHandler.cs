using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.ProxyPayaTransfer;

/// <summary>
/// انتقال پایا
/// </summary>
/// <param name="model"></param>
/// <returns></returns>
public class ProxyPayaTransferCommandHandler : IRequestHandler<ProxyPayaTransferCommand, ProxyPayaTransferCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public ProxyPayaTransferCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }


    public async Task<ProxyPayaTransferCommandResponse> Handle(ProxyPayaTransferCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<ProxyPayaTransferRequestModel>(command);
        var karizUsername = command.ProviderUsername;


        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.ProxyPayaTransfer, command.Account, command.ProviderPassword);
        requestModel.Hash = hashInfo;
        requestModel.Channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.ProxyPayaTransfer(requestModel);

        return new ProxyPayaTransferCommandResponse(true, karizResponse);
    }
}