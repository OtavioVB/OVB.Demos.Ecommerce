using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;

public interface IDependencyHealthCheck
{
    public string ServiceName { get; }
    public string ServiceVersion { get; }
    public string ServiceDescription { get; }
    public string ServiceConnectionString { get; }
    public Task<IHealthCheckServiceStatus> ReadinessHealthCheck(CancellationToken cancellationToken);
}
