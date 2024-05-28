using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pms.APIs.Configs.Filters;
using Pms.Application.Commands.OnlinePayment.AccountTransfer;
using Pms.Application.Commands.OnlinePayment.SatnaTransfer;
using Pms.Application.Commands.OnlinePayment.TransferInquiry;
using Pms.Application.Dtos.Api.OnlinePayment;

namespace Pms.APIs.Api
{
    public class OnlinePaymentController : BaseV1Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OnlinePaymentController> _logger;

        public OnlinePaymentController(IMediator mediator, ILogger<OnlinePaymentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("Satna")]
        public async Task<IActionResult> Satna(SatnaTransferRequest request)
        {
            await _mediator.Send(new SatnaTransferCommand()
            {

            });


            return Ok("resule:ok");
        }

        [HttpPost("AccountTransfer")]
        public async Task<IActionResult> AccountTransfer(AccountTransferRequest request)
        {


            await _mediator.Send(new AccountTransferCommand()
            {

            });


            return Ok("resule:ok");
        }

        [HttpPost("InquiryTransfer")]
        public async Task<IActionResult> AccountTransfer(TransferInquiryRequest request)
        {
            await _mediator.Send(new TransferInquiryCommand()
            {

            });


            return Ok("resule:ok");
        }
    }
}
