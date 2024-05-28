using MassTransit;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class MassTransitEventBusOptions
    {
        private List<(Type Event, Type EventHandler)> _consumers;

        public MassTransitEventBusOptions()
        {
            _consumers = new List<(Type Event, Type EventHandler)>();
        }

        public void AddHandler<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IConsumer<TEvent>
        {
            _consumers.Add((typeof(TEvent), typeof(TEventHandler)));
        }

        public IList<(Type Event, Type EventHandler)> GetConsumersInfo()
        {
            return _consumers.AsReadOnly();
        }
    }
}
