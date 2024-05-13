using Core.EventBus.Handlers;
using MassTransit;
using Microsoft.Extensions.Logging;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class Consumer<TEvent, TEventHandler> : IConsumer<TEvent>
      where TEvent : Event
      where TEventHandler : IEventHandler<TEvent>
    {
        readonly ILogger<Consumer<TEvent, TEventHandler>> _logger;
        readonly IEventHandler<TEvent> _EventHandler;

        public Consumer(ILogger<Consumer<TEvent, TEventHandler>> logger, TEventHandler eventHandler)
        {
            _logger = logger;
            _EventHandler = eventHandler;

        }
        public async Task Consume(ConsumeContext<TEvent> context)
        {
            await _EventHandler.Handle((TEvent)context);

        }
    }

    public delegate Task PipelineOperation<TContext>(TContext cntx);

    public delegate Task PipelineOperationMethod<TContext>(TContext cntx, PipelineOperation<TContext> next);
}
