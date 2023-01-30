using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbTracingAndMetrics(this IServiceCollection serviceCollection, 
        string serviceName, string serviceVersion, Uri endpointOtlpExporter, OtlpExportProtocol endpointOtlpProtocol)
    {
        if (serviceName == string.Empty || serviceVersion == string.Empty || (int)endpointOtlpProtocol > 1)
            throw new Exception("Is not possible to configure the Open Telemetry using Ovb Tracing and Metrics.");

        serviceCollection.AddOpenTelemetry()
            .WithTracing(p =>
            {
                p.AddSource(serviceName);
                p.SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(serviceName,serviceVersion));
                p.AddAspNetCoreInstrumentation();
                p.AddHttpClientInstrumentation();
                p.AddOtlpExporter(p =>
                {
                    p.Endpoint = endpointOtlpExporter;
                    p.Protocol = endpointOtlpProtocol;
                });
            }).StartWithHost();

        serviceCollection.AddSingleton<ITracingSource>(p =>
        {
            return new TracingSource(serviceName, serviceVersion);
        });

        serviceCollection.AddScoped<ITraceManager, TraceManager>();

        return serviceCollection;
    }
}
