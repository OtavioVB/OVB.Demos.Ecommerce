using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration;

public sealed class TracingSource : ITracingSource
{
    public ActivitySource ActivitySource { get; private set; }

    public TracingSource(string serviceName, string serviceVersion)
    {
        ActivitySource = new ActivitySource(serviceName, serviceVersion);
    }
}
