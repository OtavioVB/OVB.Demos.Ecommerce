using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs;

public sealed class HealthCheckServiceStatus : IHealthCheckServiceStatus
{
    public HealthCheckServiceStatus(string name, string version, string description, HealthCheckStatus status)
    {
        Name = name;
        Version = version;
        Description = description;
        Status = status;
    }

    public string Name { get; init; }
    public string Version { get; init; }
    public string Description { get; init; }
    public HealthCheckStatus Status { get; init; }
}
