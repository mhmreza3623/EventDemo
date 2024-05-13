using Core.EventBus.Handlers;
using MassTransit;
using System;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class MassTransitEventBusOptions
    {
        private List<Type> _consumers;

        public MassTransitEventBusOptions()
        {
            _consumers = new List<Type>();
        }

        public void AddHandler<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IConsumer<TEvent>
        {
            _consumers.Add(typeof(TEventHandler));
        }

        public IList<Type> GetConsumersInfo()
        {
            return _consumers.AsReadOnly();
        }
    }
}
