using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Pms.Domain.Events;

namespace Pms.Application.EventHandlers
{
    public class CreateClientHandler:INotificationHandler<CreatedClientEvent>
    {
        public Task Handle(CreatedClientEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
