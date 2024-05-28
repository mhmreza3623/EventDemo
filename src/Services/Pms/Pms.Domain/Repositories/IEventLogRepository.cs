using Pms.Domain.Entities.Mongo;

namespace Pms.Domain.Repositories;

public interface IEventLogRepository
{
    Task InsertLog(EventLogCollection transactionLog);
}