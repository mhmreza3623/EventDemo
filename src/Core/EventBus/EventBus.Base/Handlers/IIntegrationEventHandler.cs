using Core.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EventBus.Handlers
{
    public interface IIntegrationEventHandler<TIntegrationEvent> : IEventHandler<TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent
    {

    }
}
