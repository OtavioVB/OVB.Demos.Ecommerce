using OpenTelemetry.Exporter;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Observability Configuration
        builder.Services.AddOvbTracingAndMetrics(
            builder.Configuration["ApplicationInformation:ServiceName"]!,
            builder.Configuration["ApplicationInformation:ServiceVersion"]!,
            new Uri(builder.Configuration["Observability:OpenTelemetry:GrpcPort"]!),
            OtlpExportProtocol.Grpc);
        #endregion

        #region Infrascructure Configuration
        builder.Services.AddOvbInfrascructureConfiguration(
            builder.Configuration["Infrascructure:Databases:PostgreeSQL"]!,
            "OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data");
        #endregion

        #region Application Services Configuration
        builder.Services.AddOvbApplicationServicesConfiguration();
        #endregion

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