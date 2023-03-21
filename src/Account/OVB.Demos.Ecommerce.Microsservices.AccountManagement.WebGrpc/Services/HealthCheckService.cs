using Grpc.Core;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;

public sealed class HealthCheckService : HealthChecks.HealthChecksBase
{
    public override Task<CreateAccountOutput> ReadinessHealthCheck(ReadinessHealthCheckInput request, ServerCallContext context)
    {
        return base.ReadinessHealthCheck(request, context);
    }
}
