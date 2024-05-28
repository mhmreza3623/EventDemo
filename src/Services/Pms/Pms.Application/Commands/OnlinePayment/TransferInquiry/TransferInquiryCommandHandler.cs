using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.TransferInquiry;

public class TransferInquiryCommandHandler : IRequestHandler<TransferInquiryCommand, TransferInquiryCommandResponse>
{
    private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
    private readonly IMapper _mapper;

    public TransferInquiryCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
    {
        _paymentServiceFactory = paymentServiceFactory;
        _mapper = mapper;
    }

    public async Task<TransferInquiryCommandResponse> Handle(TransferInquiryCommand command, CancellationToken cancellationToken)
    {
        var requestModel = _mapper.Map<TransferInquiryCommandRequestModel>(command);
        var karizUsername = command.ProviderUsername;

        var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.TransferInquiry, command.Account + ";" + command.Stamp, command.ProviderPassword);

        requestModel.hash = hashInfo;
        requestModel.channel = karizUsername;
        requestModel.accountNumber = command.Account;

        var karizResponse = await _paymentServiceFactory.TransferInquiry(requestModel);

        return new TransferInquiryCommandResponse(true, karizResponse);
    }
}