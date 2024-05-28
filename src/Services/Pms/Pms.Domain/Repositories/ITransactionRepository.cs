using Pms.Domain.Entities.Mongo;

namespace Pms.Domain.Repositories;

public interface ITransactionRepository
{
    Task<bool> InsertTransactionLog(PaymentLogCollection paymentLog);
}