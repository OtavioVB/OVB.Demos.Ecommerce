using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;

public interface IHealthCheckServiceStatus
{
    public string Name { get; }
    public string Version { get; }
    public string Description { get; }
    public HealthCheckStatus Status { get; }
}
