using Core.EventBus.Events;
using Newtonsoft.Json;
using Pms.Domain.Entities.Mongo;
using Pms.Domain.Repositories;

namespace Pms.Infrastructure.Persistence
{
    internal class DomainEventHandlingExecutor : IDomainEventHandlingExecutor
    {
        private readonly IEventLogRepository _eventRespository;

        public DomainEventHandlingExecutor(IEventLogRepository eventRespository)
        {
            _eventRespository = eventRespository;
        }

        public Task SaveEventAsync(List<DomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                var log = new EventLogCollection()
                {
                    Value = JsonConvert.SerializeObject(domainEvent.Entity, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }),
                    EventName = domainEvent.EventName,
                    EventId = domainEvent.EventId,
                    CreateTime = domainEvent.CreationDate ,
                };

                _eventRespository.InsertLog(log);
            }

            return Task.CompletedTask;
        }
    }
}
