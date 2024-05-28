using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pms.Domain.Interfaces;
using SharedKernel.Common.Constants;
using SharedKernel.Common.MongoDb;
using SharedKernel.Logging.AuditLog;

namespace Pms.Infrastructure.Persistence.MongoDb.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly IMongoCollection<AuditLogCollection> _auditCollection;

        public AuditRepository(IOptions<MongodbConfig> paymentDatabase)
        {
            var mongoClient = new MongoClient(paymentDatabase.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(DataBaseConstantKeys.LogsDataBaseName);
            _auditCollection = mongoDatabase.GetCollection<AuditLogCollection>(DataBaseConstantKeys.AuditLogsDataCollection);
        }

        public async Task AuditLog(AuditLogCollection transactionLog)
        {
            await _auditCollection.InsertOneAsync(transactionLog);
        }
    }
}
