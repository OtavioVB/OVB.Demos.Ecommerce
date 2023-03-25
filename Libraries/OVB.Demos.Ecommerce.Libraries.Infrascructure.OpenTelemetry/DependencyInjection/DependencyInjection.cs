using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbObservabilityInfrascructureConfiguration(this IServiceCollection serviceCollection, string serviceName, 
        string serviceVersion)
    {
        serviceCollection.AddSingleton<ITracingSource, TracingSource>(p =>
        {
            return new TracingSource(serviceName, serviceVersion);
        });

        return serviceCollection;
    }
}
