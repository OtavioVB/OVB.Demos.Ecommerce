using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.HealthChecks;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        #region Builder Configuration

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks()
            .AddCheck<StartupCheck>("api/health/startup");

        #region Api Versioning Configuration

        builder.Services.AddApiVersioning(p =>
        {
            p.DefaultApiVersion = new ApiVersion(0, 1);
            p.AssumeDefaultVersionWhenUnspecified = true;
            p.ReportApiVersions = true;
        });

        #endregion

        #endregion

        #region Application Configuration

        var app = builder.Build();

        #region Health Checks

        app.MapHealthChecks("api/health/startup",
        options: new HealthCheckOptions
        {
            AllowCachingResponses = false,
            Predicate = healthCheck => healthCheck.Tags.Contains("startup")
        });

        #endregion

        #region Swagger Documentation

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        #endregion
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

        #endregion
    }
}