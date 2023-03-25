using Grpc.Core;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;

public sealed class HealthCheckService : HealthChecks.HealthChecksBase
{
    private readonly IDependencyHealthCheck _databaseHealthCheck;
    private readonly IRabbitMqHealthCheck _rabbitMqHealthCheck;
    private readonly IRabbitMQConfiguration _rabbitMqConfiguration;

    public HealthCheckService(
        IDependencyHealthCheck databaseHealthCheck,
        IRabbitMqHealthCheck rabbitMqHealthCheck,
        IRabbitMQConfiguration rabbitMqConfiguration)
    {
        _databaseHealthCheck = databaseHealthCheck;
        _rabbitMqHealthCheck = rabbitMqHealthCheck;
        _rabbitMqConfiguration = rabbitMqConfiguration;
    }

    public override async Task<ReadinessHealthCheckOutput> ReadinessHealthCheck(ReadinessHealthCheckInput request, ServerCallContext context)
    {
        bool hasAnyUnhealthy = false;

        var postgreeHealthCheck = await _databaseHealthCheck.ReadinessHealthCheck(context.CancellationToken);
        var rabbitMqHealthCheck = await _rabbitMqHealthCheck.ReadinessHealthCheck(_rabbitMqConfiguration, context.CancellationToken);
        if (rabbitMqHealthCheck.Status == HealthCheckStatus.Unhealthy || postgreeHealthCheck.Status == HealthCheckStatus.Unhealthy)
            hasAnyUnhealthy = true;



        var response = new ReadinessHealthCheckOutput();
        response.Services.AddRange(Convert(postgreeHealthCheck, rabbitMqHealthCheck));
        if (hasAnyUnhealthy == true)
            response.Ready = HealthCheckStatus.Unhealthy.ToString();
        else
            response.Ready = HealthCheckStatus.Healthy.ToString();

        return response;
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
