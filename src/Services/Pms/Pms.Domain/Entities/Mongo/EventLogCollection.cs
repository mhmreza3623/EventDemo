using SharedKernel.Common.MongoDb;

namespace Pms.Domain.Entities.Mongo;

public class EventLogCollection : MongoBaseEntity
{
    public string Value { get; set; }
    public string EventName { get; set; }
    public Guid EventId { get; set; }
}