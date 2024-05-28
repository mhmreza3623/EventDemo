using Core.EventBus.Events;
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
            foreach (var @event in events)
            {
                var log = new EventLogCollection()
                {
                    Value = @event.Value,
                    EventName = @event.EventName,
                    EventId = @event.EventId,
                    CreateTime = @event.CreationDate,
                };

                _eventRespository.InsertLog(log);
            }

            return Task.CompletedTask;
        }
    }
}
