using Account.APIs.App.EventHandlers.IntegrationEvents;
using Core.EventBus.Masstransit;
using System.Reflection;
using MassTransit;
using Pms.Infrastructure.Persistence.EF;
using Pms.Infrastructure.Persistence.MongoDb;
using SharedModels;
using Logging.Core.Middlewares;
using Logging.Core.Serilog;
using Shared.AuditLog.Middlewares;
using Shared.AuditLog.Persistence.MongoDb;

namespace Account.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //audit
            builder.Services.AddAuditConfig(builder.Configuration);
            //serilog
            builder.AddSerilogConfig(builder.Configuration);
            //DataBases
            builder.Services.AddEFConfig(builder.Configuration);
            builder.Services.AddMongodbConfig(builder.Configuration);
            
            //MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //ServiceBus
            builder.Services.AddMassTransitConsumers(builder.Configuration, h =>
            {
                h.AddHandler<TransactionCreated, TransactionCreatedHandler>();
            });
            builder.Services.AddTransient<IConsumer<TransactionCreated>, TransactionCreatedHandler>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //global error logs
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            //audit
            app.UseMiddleware<RequestLoggerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/health", () => { return Task.CompletedTask; });

            app.Run();
        }
    }
}