using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration;

public sealed class TracingSource : ITracingSource
{
    public TracingSource(string serviceName, string serviceVersion)
    {
        ActivitySource = new ActivitySource(serviceName, serviceVersion);
    }

    public ActivitySource ActivitySource { get; init; }
}
