using Core.EventBus.Interfaces;
using MediatR;
using Pms.Domain.EntityCollections;
using Pms.Domain.Enums;
using Pms.Domain.Repositories;
using SharedModels.TransactionEvents.Integeration;

namespace Pms.Application.Commands
{

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, BaseResponse>
    {
        readonly IEventPublisher _eventPublisher;
        private readonly ITransactionRepository _transactionRepository;

        public CreateTransactionCommandHandler(IEventPublisher eventPublisher, ITransactionRepository transactionRepository)
        {
            _eventPublisher = eventPublisher;
            this._transactionRepository = transactionRepository;
        }

        public async Task<BaseResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            TransactionLogCollection transactionLog = new()
            {
                Amount = request.Amount,
                CreateTime = DateTime.UtcNow,
                DistinationAccount = request.Destination,
                SourceAccount = request.Source,
            };
            var respone = await _transactionRepository.InsertTransactionLog(transactionLog);

            await _eventPublisher.PublishAsync(new TransactionCreated(Guid.NewGuid(), transactionLog.Id, PaymentType.AccountTransfer.ToString(), "source", "desc"));
            await _eventPublisher.PublishAsync(new PaymentCreated(Guid.NewGuid(), transactionLog.Id, PaymentType.AccountTransfer.ToString(), "source", "desc"));

            return new SucceedResponse(null);

        }
    }

}
