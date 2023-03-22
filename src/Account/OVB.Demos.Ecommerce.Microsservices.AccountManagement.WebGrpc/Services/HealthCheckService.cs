using Grpc.Core;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;

public sealed class HealthCheckService : HealthChecks.HealthChecksBase
{
    private readonly IDependencyHealthCheck _databaseHealthCheck;

    public HealthCheckService(IDependencyHealthCheck databaseHealthCheck)
    {
        _databaseHealthCheck = databaseHealthCheck;
    }

    public override async Task<ReadinessHealthCheckOutput> ReadinessHealthCheck(ReadinessHealthCheckInput request, ServerCallContext context)
    {
        bool hasAnyUnhealthy = false;

        var postgreeHealthCheck = await _databaseHealthCheck.ReadinessHealthCheck(context.CancellationToken);
        if (postgreeHealthCheck.Status == HealthCheckStatus.Unhealthy)
            hasAnyUnhealthy = true;


        var response = new ReadinessHealthCheckOutput();
        response.Services.AddRange(Convert(postgreeHealthCheck));
        if (hasAnyUnhealthy == true)
        {
            response.Ready = HealthCheckStatus.Unhealthy.ToString();
            return response;
        }
        else
        {
            response.Ready = HealthCheckStatus.Healthy.ToString();
            return response;
        }
    }

    private IEnumerable<ServiceReadiness> Convert(params IHealthCheckServiceStatus[] status)
    {
        var services = new List<ServiceReadiness>();

        foreach (var statu in status)
        {
            services.Add(new ServiceReadiness()
            {
                ServiceDescription = statu.Description,
                ServiceIsReady = statu.Status.ToString(),
                ServiceName = statu.Name,
                ServiceVersion = statu.Version,
            });
        }

        return services;
    }
}
