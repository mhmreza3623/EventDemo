using DataBase.Core;
using DataModels.Core.Common;
using DataModels.Core.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Shared.AuditLog.Persistence.MongoDb.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly IMongoCollection<AuditLogCollection> _auditCollection;

        public AuditRepository(IOptions<MongodbConfig> paymentDatabase)
        {
            var mongoClient = new MongoClient(paymentDatabase.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(DataBaseConstantKeys.AuditLogsDataBaseName);
            _auditCollection = mongoDatabase.GetCollection<AuditLogCollection>(DataBaseConstantKeys.AuditLogsDataCollection);
        }

        public async Task AuditLog(AuditLogCollection transactionLog)
        {
            await _auditCollection.InsertOneAsync(transactionLog);
        }
    }
}
