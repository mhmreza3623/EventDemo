using System.Text;
using Core.EventBus.Masstransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Pms.Application.Mapper;
using Pms.Infrastructure.Persistence.EF;
using Pms.Infrastructure.Persistence.MongoDb;
using Serilog;
using SharedKernel.Identities;
using SharedKernel.Logging.AuditLog;
using SharedKernel.Logging.Serilog;
using Pms.APIs.Configs.Middlewares;
using Pms.Application;
using Pms.Application.Commands.OnlinePayment.AccountDeposit;
using Pms.Domain.Entities;
using Pms.Infrastructure;
using SharedKernel.Common;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Payment Switch",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

//audit
builder.Services.AddAuditConfig(builder.Configuration);

//serilog
builder.AddSerilogConfig(builder.Configuration);

//persistence
builder.Services.AddPersistence(builder.Configuration);

//mediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(AccountDepositCommand)));

//ServiceBus
builder.Services.AddMassTransitConsumers(builder.Configuration);

//JWT
builder.Services.AddJwtConfig(builder.Configuration);

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "paymentApi";
        options.Authority = "https://localhost:7044";
    });

//DomainServices
builder.Services.AddDomainServices(builder.Configuration);

//InfraServices
builder.Services.AddPaymentProviderServices(builder.Configuration);

//Mapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddApplicationMapperProfile();

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
app.UseMiddleware<ActionLogMiddleware>();

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
