using MediatR;
using MicroservicePHC.Application.Common.PipelineBehavirs;
using MicroservicePHC.Application.EntityExample.Commands.CreateEntityExampleCommand;
using MicroservicePHC.Domain.Common;
using MicroservicePHC.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Scalar.AspNetCore;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); 

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };
    });

// Add Mediator

builder.Services.AddMediatR(cfg =>
{
    // Usa un tipo que esté en el assembly donde están los handlers
    cfg.RegisterServicesFromAssembly(typeof(CreateEntityExampleCommandHandler).Assembly);
});

builder.Services.AddDbContext<MicroservicePHCDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlServerConnection"));
});

//! Observability

//! Serilog Configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("serilog.json", optional: false);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

//! OpenTelemetry and Jaeger
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder =>
    {
        tracerProviderBuilder
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MicroservicePHC"))
            .AddSource("MicroservicePHC")
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddJaegerExporter(options =>
            {
                options.AgentHost = "localhost";
                options.AgentPort = 6831;
            });
    });

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


var app = builder.Build();

app.UseMiddleware<TraceIdEnricherMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

