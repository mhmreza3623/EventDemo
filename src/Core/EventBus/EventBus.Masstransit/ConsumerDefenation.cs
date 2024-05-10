using Core.EventBus.Handlers;
using MassTransit;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class ConsumerDefenation<TConsumer, TEvent, TEventHandler> : ConsumerDefinition<TConsumer>
      where TConsumer : class, IConsumer<TEvent>
      where TEvent : Event
      where TEventHandler : IEventHandler<TEvent>
    {
        public ConsumerDefenation(IEndpointNameFormatter endpointNameFormatter)
        {
            EndpointName = $"{endpointNameFormatter.SanitizeName(typeof(TEvent).Name)}_{typeof(TEventHandler).Assembly.GetName().Name.ToLower().Replace('.', '-')}";
        }
    }
}
