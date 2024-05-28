namespace Pms.APIs.Configs.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
