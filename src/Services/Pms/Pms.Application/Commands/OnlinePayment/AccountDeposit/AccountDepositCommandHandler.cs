using AutoMapper;
using MediatR;
using Pms.Application.Common;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Interfaces;
using SharedKernel.Common.Encryotions;

namespace Pms.Application.Commands.OnlinePayment.AccountDeposit
{

    /// <summary>
    /// واریز به حساب
    /// </summary>
    /// <param name="accountVM"></param>
    /// <returns></returns>
    public class AccountDepositCommandHandler : IRequestHandler<AccountDepositCommand, AccountDepositCommandResponse>
    {
        private readonly IKarizPaymentServiceProxy _paymentServiceFactory;
        private readonly IMapper _mapper;

        public AccountDepositCommandHandler(IKarizPaymentServiceProxy paymentServiceFactory, IMapper mapper)
        {
            _paymentServiceFactory = paymentServiceFactory;
            _mapper = mapper;
        }
        public async Task<AccountDepositCommandResponse> Handle(AccountDepositCommand command, CancellationToken cancellationToken)
        {
            var requestModel = _mapper.Map<AccountDepositRequestModel>(command);
            var karizUsername = command.ProviderUsername;
            var hashInfo = Encryption.ComputeSha256Hash(karizUsername, KarizConsts.AccountDeposit, command.AccountNumber, command.ProviderPassword);
            requestModel.hash = hashInfo;
            requestModel.channel = karizUsername;

            var karizResponse = await _paymentServiceFactory.AccountDeposit(requestModel);

            return new AccountDepositCommandResponse(true, karizResponse);
        }
    }

}
