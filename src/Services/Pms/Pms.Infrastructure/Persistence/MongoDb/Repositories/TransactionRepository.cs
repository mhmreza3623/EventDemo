using Pms.Domain.EntityCollections;
using Pms.Domain.Repositories;

namespace Pms.Infrastructure.Persistence.MongoDb.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IGeneralMongoRepository<TransactionLogCollection> _transactonMongoRepository;

        public TransactionRepository(IGeneralMongoRepository<TransactionLogCollection> transactonMongoRepository)
        {
            _transactonMongoRepository = transactonMongoRepository;
        }

        public async Task<bool> InsertTransactionLog(TransactionLogCollection transactionLog)
        {
            return await _transactonMongoRepository.InsertAsync(transactionLog);
        }
    }
}
