
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.HealthChecks;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHealthChecks()
            .AddCheck<StartupCheck>("api/health/startup");

        var app = builder.Build();
        app.MapHealthChecks(
            "api/health/startup",
            options: new HealthCheckOptions
            {
                AllowCachingResponses = false,
                Predicate = healthCheck => healthCheck.Tags.Contains("startup")
            }
        );
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}