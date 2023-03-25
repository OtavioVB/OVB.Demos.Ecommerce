using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Exporter;
using OpenTelemetry;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Trace.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbObservabilityInfrascructureConfiguration(this IServiceCollection serviceCollection, string serviceName, 
        string serviceVersion, Uri endpointOtlpExporter, OtlpExportProtocol endpointOtlpProtocol)
    {
        serviceCollection.AddSingleton<ITracingSource, TracingSource>(p =>
        {
            return new TracingSource(serviceName, serviceVersion);
        });

        serviceCollection.AddSingleton<ITraceManager, TraceManager>();

        return serviceCollection;
    }
}
