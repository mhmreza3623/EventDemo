using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Logging.Core.Serilog
{
    public static class SerilogServiceCollection
    {
        public static void AddSerilogConfig(this WebApplicationBuilder builder,IConfigurationManager configuration)
        {
            configuration.AddJsonFile("configs/SerilogSettings.json", optional: true, reloadOnChange: true);

            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("JobService", LogEventLevel.Debug)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
        }
    }
}
