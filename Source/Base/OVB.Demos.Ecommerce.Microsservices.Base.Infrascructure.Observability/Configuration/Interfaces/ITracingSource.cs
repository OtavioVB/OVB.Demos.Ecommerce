using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration.Interfaces;

public interface ITracingSource
{
    public ActivitySource ActivitySource { get; }
}
