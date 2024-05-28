using Identity.Infrastructure.Persistence;
using SharedKernel.Identities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//JWT
builder.Services.AddJWtConfig(builder.Configuration);

//DataBase
builder.Services.AddDbContextConfig(builder.Configuration);


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
