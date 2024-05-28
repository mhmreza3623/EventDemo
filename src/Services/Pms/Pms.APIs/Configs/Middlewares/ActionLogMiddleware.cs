using System.Text;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using Pms.Domain.Interfaces;
using SharedKernel.Logging.AuditLog;

namespace Pms.APIs.Configs.Middlewares
{
    public class ActionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly IAuditRepository _auditRepository;


        public ActionLogMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger,
            IAuditRepository auditRepository)
        {
            _next = next;
            _logger = logger;
            _auditRepository = auditRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            string responseBody = string.Empty;
            string requestBody = string.Empty;
            try
            {
                context.Request.EnableBuffering();
                requestBody = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();
                context.Request.Body.Position = 0;
                Console.WriteLine($"Request body: {requestBody}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception reading request: {ex.Message}");
            }

            var originalBody = context.Response.Body;
            var statusCode = context.Response.StatusCode;
            try
            {
                using var memStream = new MemoryStream();
                context.Response.Body = memStream;

                // call to the following middleware 
                // response should be produced by one of the following middlewares
                await _next(context);

                memStream.Position = 0;
                responseBody = new StreamReader(memStream).ReadToEnd();

                memStream.Position = 0;
                await memStream.CopyToAsync(originalBody);
                Console.WriteLine(responseBody);
            }
            finally
            {
                context.Response.Body = originalBody;
            }

            Task.Factory.StartNew(() =>
            {
                try
                {

                    var controllerActionDescriptor = context?
                        .GetEndpoint()?
                        .Metadata?
                        .GetMetadata<ControllerActionDescriptor>();

                    var controllerName = controllerActionDescriptor.ControllerName;
                    var actionName = controllerActionDescriptor.ActionName;

                    _auditRepository.AuditLog(new AuditLogCollection()
                    {
                        ActionName = actionName,
                        ControllerName = controllerName,
                        RequestBody = requestBody,
                        StatusCode = statusCode.ToString(),
                        ResponseBody = JsonConvert.SerializeObject(responseBody, Formatting.None,
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            })
                    });
                }
                catch (Exception e)
                {
                }
            });
        }
    }
}
