using Event = Core.EventBus.Events.Event;

namespace Core.EventBus.Masstransit
{
    public class ConsumerPipelineContext
    {
        public Event Event { get; set; }
    }
}
