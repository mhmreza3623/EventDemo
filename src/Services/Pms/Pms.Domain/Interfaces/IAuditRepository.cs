using SharedKernel.Logging.AuditLog;

namespace Pms.Domain.Interfaces;

public interface IAuditRepository
{
    Task AuditLog(AuditLogCollection transactionLog);
}