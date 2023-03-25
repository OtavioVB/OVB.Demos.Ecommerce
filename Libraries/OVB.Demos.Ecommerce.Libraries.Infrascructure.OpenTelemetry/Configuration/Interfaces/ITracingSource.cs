using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration.Interfaces;

public interface ITracingSource
{
    public ActivitySource ActivitySource { get; }
}
