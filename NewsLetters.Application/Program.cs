using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using NewsLetters.Infrastructure.CrossCutting.Mapper;
using NewsLetters.Infrastructure.Data;
using NewsLetters.Service;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add serilog on the application builder
var logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add other services here...
builder.Services.AddMySqlConnection();
builder.Services.AddNewsLettersServices();
builder.Services.AddMapper();

// Add the application singleton
builder.Services.AddSingleton(logger);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddLogging();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(ops =>
{  
    ops.DefaultApiVersion = new ApiVersion(1, 0);
    ops.AssumeDefaultVersionWhenUnspecified = true; 
    ops.ReportApiVersions = true;
    ops.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
