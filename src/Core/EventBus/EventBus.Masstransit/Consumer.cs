using MassTransit;
using Microsoft.Extensions.Logging;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class Consumer<TEvent, TEventHandler> : IConsumer<TEvent>, IMassTransitEventBusPipelineBehaviour
      where TEvent : Event
      where TEventHandler : IEventHandler<TEvent>
    {
        readonly ILogger<Consumer<TEvent, TEventHandler>> _logger;
        readonly IEventHandler<TEvent> _EventHandler;
        private readonly IList<IMassTransitEventBusPipelineBehaviour> _pipelineBehaviours;

        public Consumer(ILogger<Consumer<TEvent, TEventHandler>> logger, TEventHandler eventHandler, IList<IMassTransitEventBusPipelineBehaviour> massTransitEventBusPipelineBehaviours)
        {
            _logger = logger;
            _EventHandler = eventHandler;
            _pipelineBehaviours = massTransitEventBusPipelineBehaviours;

            _pipelineBehaviours.Add(this);
        }

        public async Task Consume(ConsumeContext<TEvent> context)
        {
            _logger.LogInformation($"Message received in generic masstransit consumer!", context.Message);

            var pipeContext = new ConsumerPipelineContext { Event = context.Message };

            await InternalExecute(pipeContext, 0);
        }

        public async Task Execute(ConsumerPipelineContext context, PipelineOperation<ConsumerPipelineContext> next)
        {
            await _EventHandler.Handle((TEvent)context.Event);
        }

        private async Task InternalExecute(ConsumerPipelineContext context, int index)
        {
            if (_pipelineBehaviours.ElementAtOrDefault(index) != null)
            {
                await _pipelineBehaviours[index].Execute(context, async cntx => await InternalExecute(cntx, index + 1));
            }
            else
                await Task.CompletedTask;
        }
    }

    public interface IMassTransitEventBusPipelineBehaviour
    {
        Task Execute(ConsumerPipelineContext context, PipelineOperation<ConsumerPipelineContext> next);
    }

    public class ConsumerPipelineContext
    {
        public Event Event { get; set; }
    }

    public delegate Task PipelineOperation<TContext>(TContext cntx);

    public delegate Task PipelineOperationMethod<TContext>(TContext cntx, PipelineOperation<TContext> next);
}
