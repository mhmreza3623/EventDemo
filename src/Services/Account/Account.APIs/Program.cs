using Account.APIs.App.EventHandlers.IntegrationEvents;
using Core.EventBus.Handlers;
using Core.EventBus.Masstransit;
using SharedModels.PaymentEvents;
using System.Reflection;

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

            //MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //ServiceBus
            builder.Services.AddMassTransitConfigAsync(builder.Configuration, o =>
            {
                o.AddHandler<PaymentCreated, PaymentCreatedHandler>();
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/health", () => { return Task.CompletedTask; });

            app.Run();
        }
    }
}