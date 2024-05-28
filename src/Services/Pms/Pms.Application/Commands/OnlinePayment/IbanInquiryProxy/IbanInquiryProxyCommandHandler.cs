using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.IbanInquiryProxy;

/// <summary>
/// استعلام شناسه شبا
/// </summary>
/// <param name="inquiryProxyVm"></param>

public class IbanInquiryProxyCommandHandler : IRequestHandler<IbanInquiryProxyCommand, IbanInquiryProxyCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _proxy;
    private readonly IMapper _mapper;

    public IbanInquiryProxyCommandHandler(IKarizPaymentServiceProxy proxy, IMapper mapper)
    {
        _proxy = proxy;
        _mapper = mapper;
    }

    public async Task<IbanInquiryProxyCommandResponse> Handle(IbanInquiryProxyCommand command, CancellationToken cancellationToken)
    {

        var requestModel = _mapper.Map<IbanInquiryProxyRequestModel>(command);
        var karizUsername = command.ProviderUsername;

        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.IbanInquiryProxy, command.Iban, command.ProviderPassword);
        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _proxy.IbanInquiryProxy(requestModel);

        return new IbanInquiryProxyCommandResponse(true, karizResponse);
    }
}