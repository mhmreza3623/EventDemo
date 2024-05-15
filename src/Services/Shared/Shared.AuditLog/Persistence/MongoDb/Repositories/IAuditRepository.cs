using DataModels.Core.Common;

namespace Shared.AuditLog.Persistence.MongoDb.Repositories;

public interface IAuditRepository
{
    Task AuditLog(AuditLogCollection transactionLog);
}