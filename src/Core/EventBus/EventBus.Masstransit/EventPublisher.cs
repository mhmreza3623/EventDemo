using Core.EventBus.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class EventPublisher : IEventPublisher
    {
        readonly IPublishEndpoint _publishEndpoint;
        readonly ILogger<EventPublisher> _logger;
        public EventPublisher(IPublishEndpoint publishEndpoint, IBusControl busControl, IServiceProvider serviceProvider, ILogger<EventPublisher> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }
        public async Task Publish(Event evt)
        {
            await _publishEndpoint.Publish(evt, evt.GetType());
        }

        public async Task PublishAsync(Event evt)
        {
            await _publishEndpoint.Publish(evt, evt.GetType());
        }
    }
}
