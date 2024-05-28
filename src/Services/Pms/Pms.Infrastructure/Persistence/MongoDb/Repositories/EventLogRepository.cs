using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pms.Domain.Entities.Mongo;
using SharedKernel.Common.Constants;
using SharedKernel.Common.MongoDb;
using Pms.Domain.Repositories;

namespace Pms.Infrastructure.Persistence.MongoDb.Repositories
{
    internal class EventLogRepository : IEventLogRepository
    {
        private readonly IMongoCollection<EventLogCollection> _eventLogCollection;

        public EventLogRepository(IOptions<MongodbConfig> paymentDatabase)
        {
            var mongoClient = new MongoClient(paymentDatabase.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(DataBaseConstantKeys.LogsDataBaseName);
            _eventLogCollection = mongoDatabase.GetCollection<EventLogCollection>(DataBaseConstantKeys.EventLogCollection);
        }

        public Task InsertLog(EventLogCollection transactionLog)
        {
            _eventLogCollection.InsertOneAsync(transactionLog);

            return Task.CompletedTask;
        }
    }
}
