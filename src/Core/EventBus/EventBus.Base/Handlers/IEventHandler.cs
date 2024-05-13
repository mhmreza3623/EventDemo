using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Handlers
{
    public interface IEventHandler<in TEvent> 
       where TEvent : Event
    {
        Task Handle(TEvent evt);
    }
}
