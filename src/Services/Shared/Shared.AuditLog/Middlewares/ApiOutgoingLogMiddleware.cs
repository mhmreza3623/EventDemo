using System.Net.Http;
using System.Text;
using DataModels.Core.Common;
using Logging.Core.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.AuditLog.Persistence.MongoDb.Repositories;

namespace Shared.AuditLog.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly IAuditRepository _auditRepository;


        public RequestLoggerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger,
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
                    _auditRepository.AuditLog(new AuditLogCollection()
                    {
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
