using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.ProxyInquiry;

public class ProxyInquiryCommandHandler : IRequestHandler<ProxyInquiryCommand, KarizProxyInquiryCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public ProxyInquiryCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }


    public async Task<KarizProxyInquiryCommandResponse> Handle(ProxyInquiryCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<ProxyInquiryCommandRequestModel>(command);
        var karizUsername = command.ProviderUsername;

        var num = $"{command.Date};{command.FcSeqNo}";
        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.ProxyInquiry, num, command.ProviderPassword);

        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;

        var karizResponse = await _paymentServiceFactory.ProxyInquiry(requestModel);

        return new KarizProxyInquiryCommandResponse(true, karizResponse);

    }
}