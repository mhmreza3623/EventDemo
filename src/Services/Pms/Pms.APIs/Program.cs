using Core.EventBus.Masstransit;
using Logging.Core.Serilog;
using Pms.Infrastructure.Persistence.EF;
using Pms.Infrastructure.Persistence.MongoDb;
using Pms.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//serilog
builder.AddSerilogConfig(builder.Configuration);

//DataBases
builder.Services.AddEFConfig(builder.Configuration);
builder.Services.AddMongodbConfig(builder.Configuration);

//mediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateTransactionCommand)));


//ServiceBus
//builder.Services.AddMassTransitConfigAsync(builder.Configuration);
builder.Services.AddMassTransitConsumers(builder.Configuration);


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

//health check
app.MapGet("/health", () => { return Task.CompletedTask; });

app.Run();
