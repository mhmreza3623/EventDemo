using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pms.Application.Commands.Authenticate.VerifyToken;
using System.Net;
using MediatR;
using Pms.APIs.Api;
using Pms.APIs.Models;
using Pms.Domain.Common.Enums;

namespace Pms.APIs.Configs.Filters
{
    public class IdentifyClientAttribute : ActionFilterAttribute
    {
        private readonly IMediator _mediator;

        public IdentifyClientAttribute()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var _mediator = context.HttpContext.RequestServices.GetService<IMediator>();

            var authorize = context.HttpContext.Request.Headers.Authorization;

            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var verifyResponse = _mediator.Send(new VerifyTokenCommand()
                {
                    Token = authorize.ToString().Replace("Bearer", "").Replace("bearer", "")
                })
                .GetAwaiter()
                .GetResult();

            if (!verifyResponse.Succeed)
            {
                var response = context.HttpContext.Response;
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new UnauthorizedObjectResult(ErrorCodes.InvalidClientId);
                return;
            }
            ((BaseV1Controller)context.Controller).Client = new ClientModel()
            {
                IsActive = verifyResponse.IsActive,
                ClientName = verifyResponse.ClientName,
                ClientUxId = verifyResponse.ClientUxId,
                DisplayName = verifyResponse.DisplayName,
                Id = verifyResponse.Id,
            };


            base.OnActionExecuting(context);
        }
    }
}
