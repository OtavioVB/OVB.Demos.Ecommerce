using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.HealthChecks;

public sealed class StartupCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(HealthCheckResult.Healthy());
    }
}
