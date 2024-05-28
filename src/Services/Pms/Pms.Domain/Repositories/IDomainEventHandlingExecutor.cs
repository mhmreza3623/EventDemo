using Core.EventBus.Events;

namespace Pms.Domain.Repositories;

public interface IDomainEventHandlingExecutor
{
    Task SaveEventAsync(List<DomainEvent> events);
}