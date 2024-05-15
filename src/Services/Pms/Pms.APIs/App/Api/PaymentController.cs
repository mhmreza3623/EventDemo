using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pms.Application.Commands;
using Pms.Domain.Dtos;

namespace Pms.APIs.App.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IMediator mediator, ILogger<PaymentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("createPayment")]
        public async Task<IActionResult> CreateOrder(TransactionDto request)
        {

            _logger.LogInformation("Seri Log is Working");

            await _mediator.Send(new CreateTransactionCommand(request.Source, request.Distination, request.Amount));
            return Ok("resule:ok");
        }
    }
}
