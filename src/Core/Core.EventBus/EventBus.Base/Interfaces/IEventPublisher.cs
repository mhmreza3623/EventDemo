using Core.EventBus.Events;

namespace Core.EventBus.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish(Event evt);
        Task PublishAsync(Event evt);
    }
}
