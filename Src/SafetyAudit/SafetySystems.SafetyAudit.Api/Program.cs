using Microsoft.AspNetCore.Mvc;
using SafetySystems.Common.ServiceDefaults;
using SafetySystems.SafetyAudit.Application;
using SafetySystems.SafetyAudit.Domain;
using SafetySystems.SafetyAudit.Infrastructure;

namespace SafetySystems.SafetyAudit.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddControllers(options =>
        {
            // Define MediaType limits ...
            options.Filters.Add(new ProducesAttribute("application/json")); // Response limit
            options.Filters.Add(new ConsumesAttribute("application/json")); // Request limit
            options.ReturnHttpNotAcceptable = true; // Force client to only request media types based on the above limits.
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSafetySystemsDomain();
        builder.Services.AddSafetySystemsInfrastructure();
        builder.Services.AddSafetySystemsApplication();

        var app = builder.Build();
        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}

