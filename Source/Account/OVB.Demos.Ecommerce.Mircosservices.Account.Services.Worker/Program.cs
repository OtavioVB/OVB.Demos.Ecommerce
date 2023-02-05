using Npgsql;
using OpenTelemetry.Exporter;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.DependencyInjection;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.DependencyInjection;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddOvbDefaultDatabaseConfiguration(hostContext.Configuration["Infrascructure:Databases:PostgreeSQL"]!);

            services.AddOvbMessengerConfiguration(
                hostName: hostContext.Configuration["Messenger:RabbitMQ:HostName"]!,
                virtualHost: hostContext.Configuration["Messenger:RabbitMQ:VirtualHost"]!,
                username: hostContext.Configuration["Messenger:RabbitMQ:Username"]!,
                password: hostContext.Configuration["Messenger:RabbitMQ:Password"]!,
                clientProviderName: hostContext.Configuration["Messenger:RabbitMQ:ClientProviderName"]!,
                port: (int)hostContext.Configuration["Messenger:RabbitMQ:Port"]!);

            services.AddOvbTracingAndMetrics(
                serviceName: hostContext.Configuration["Observability:OpenTelemetry:ServiceName"]!,
                serviceVersion: hostContext.Configuration["Observability:OpenTelemetry:ServiceVersion"]!, 
                endpointOtlpExporter: new Uri(hostContext.Configuration["Observability:OpenTelemetry:GrpcPort"]!), 
                endpointOtlpProtocol: OtlpExportProtocol.Grpc);

            services.AddHostedService<Worker>();
        })
        .Build();

        host.Run();
    }
}