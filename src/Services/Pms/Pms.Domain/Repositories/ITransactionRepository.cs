using Pms.Domain.EntityCollections;

namespace Pms.Domain.Repositories;

public interface ITransactionRepository
{
    Task<bool> InsertTransactionLog(TransactionLogCollection transactionLog);
}