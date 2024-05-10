using MassTransit;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class MassTransitEventBusOptions
    {
        private List<(Type consumerType, Type eventType, Type handlerType, Type consumerDefenationType, Type consumerDefenationInterface)> _consumers;
        private List<Type> _pipelineBehaviours;

        public MassTransitEventBusOptions()
        {
            _consumers = new List<(Type consumerType, Type eventType, Type handlerType, Type consumerDefenationType, Type consumerDefenationInterface)>();
            _pipelineBehaviours = new List<Type>();
        }

        public void AddHandler<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            _consumers.Add((typeof(Consumer<TEvent, TEventHandler>), typeof(TEvent), typeof(TEventHandler), typeof(ConsumerDefenation<Consumer<TEvent, TEventHandler>, TEvent, TEventHandler>), typeof(IConsumerDefinition<Consumer<TEvent, TEventHandler>>)));
        }

        public IList<(Type consumerType, Type eventType, Type handlerType, Type consumerDefenationType, Type consumerDefenationInterface)> GetConsumersInfo()
        {
            return _consumers.AsReadOnly();
        }

        public void AddToExecutePipeline<PipelineBehaviour>() where PipelineBehaviour : IMassTransitEventBusPipelineBehaviour
        {
            _pipelineBehaviours.Add(typeof(PipelineBehaviour));
        }

        public IList<Type> GetPipelineBehaviors()
        {
            return _pipelineBehaviours.AsReadOnly();
        }
    }

    public interface IEventHandler<in TEvent>
       where TEvent : Event
    {
        Task Handle(TEvent evt);
    }

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
