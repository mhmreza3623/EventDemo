using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Logging.Core.Serilog
{
    public static class SerilogServiceCollection
    {
        public static void AddSerilogConfig(this WebApplicationBuilder builder,IConfigurationManager configuration)
        {
            //configuration.AddJsonFile("configs/SerilogSettings.json", optional: true, reloadOnChange: true);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                    .AddJsonFile("configs/SerilogSettings.json")
                    .Build())
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
        }
    }
}
