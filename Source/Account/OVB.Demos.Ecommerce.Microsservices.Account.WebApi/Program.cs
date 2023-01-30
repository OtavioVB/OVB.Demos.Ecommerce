using OpenTelemetry.Exporter;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Observability Configuration
        builder.Services.AddOvbTracingAndMetrics(
            builder.Configuration["ApplicationInformation:ServiceName"]!,
            builder.Configuration["ApplicationInformation:ServiceVersion"]!,
            new Uri(builder.Configuration["Observability:OpenTelemetry:GrpcPort"]!),
            OtlpExportProtocol.Grpc);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}