using Npgsql;
using OpenTelemetry.Exporter;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.DependencyInjection;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddOvbDefaultDatabaseConfiguration(hostContext.Configuration["Infrascructure:Databases:PostgreeSQL"]!);

            services.AddOvbTracingAndMetrics(hostContext.Configuration["Observability:OpenTelemetry:ServiceName"]!,
                hostContext.Configuration["Observability:OpenTelemetry:ServiceVersion"]!, 
                new Uri(hostContext.Configuration["Observability:OpenTelemetry:GrpcPort"]!), 
                OtlpExportProtocol.Grpc);

            services.AddHostedService<Worker>();
        })
        .Build();

        host.Run();
    }
}