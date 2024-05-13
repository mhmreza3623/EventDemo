using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pms.Application.Commands;
using Pms.Domain.Dtos;

namespace Pms.APIs.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(TransactionDto request)
        {
            await _mediator.Send(new CreateTransactionCommand(request.Source,request.Distination,request.Amount));
            return Ok();
        }
    }
}
