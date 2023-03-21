using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces;

public interface IHealthCheck
{
    public string ServiceName { get; }
    public string ServiceVersion { get; }
    public string ServiceDescription { get; }

    public IHealthCheckServiceStatus ReadinessHealthCheck();
}
