using Core.EventBus.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Pms.APIs.App.Core.Models;
using SharedModels.PaymentEvents;

namespace Pms.APIs.App.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        readonly IEventPublisher _eventBus;

        public PaymentController(IEventPublisher publishEndpoint)
        {
            _eventBus = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(PaymentDto orderDto)
        {
            await _eventBus.Publish(new PaymentCreated(Guid.NewGuid(), orderDto.SourceName, orderDto.DistinationName, orderDto.Price));

            return Ok();
        }
    }
}
