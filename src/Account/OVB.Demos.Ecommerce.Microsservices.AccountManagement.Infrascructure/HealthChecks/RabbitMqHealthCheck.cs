using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks;

public sealed class RabbitMqHealthCheck : IRabbitMqHealthCheck
{
    public string ServiceName { get; init; }
    public string ServiceVersion { get; init; }
    public string ServiceDescription { get; init; }

    public RabbitMqHealthCheck(string serviceName, string serviceVersion, string serviceDescription)
    {
        ServiceName = serviceName;
        ServiceVersion = serviceVersion;
        ServiceDescription = serviceDescription;
    }

    public async Task<IHealthCheckServiceStatus> ReadinessHealthCheck(IRabbitMQConfiguration configurationRabbitMq, CancellationToken cancellationToken)
    {
        try
        {
            configurationRabbitMq.GetChannel();
            return await Task.FromResult(
                new HealthCheckServiceStatus(ServiceName, ServiceVersion, ServiceDescription, HealthCheckStatus.Healthy));
        }
        catch
        {
            return await Task.FromResult(
                new HealthCheckServiceStatus(ServiceName, ServiceVersion, ServiceDescription, HealthCheckStatus.Unhealthy));
        }
    }
}
