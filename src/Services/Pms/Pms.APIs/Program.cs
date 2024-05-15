using Core.EventBus.Masstransit;
using Logging.Core.Serilog;
using Pms.Infrastructure.Persistence.EF;
using Pms.Infrastructure.Persistence.MongoDb;
using Pms.Application.Commands;
using Serilog;
using Logging.Core.Middlewares;
using Shared.AuditLog.Persistence.MongoDb;
using Shared.AuditLog.Middlewares;

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
//mediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateTransactionCommand)));
//ServiceBus
builder.Services.AddMassTransitConsumers(builder.Configuration);

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

//health check
app.MapGet("/health", () =>
{
    Log.Logger.Information("Pms Health Check log. I'm alive!");

    return Task.CompletedTask;
});

app.Run();
