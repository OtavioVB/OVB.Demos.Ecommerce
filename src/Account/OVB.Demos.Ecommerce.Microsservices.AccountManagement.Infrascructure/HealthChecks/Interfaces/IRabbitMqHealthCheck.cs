using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;

public interface IRabbitMqHealthCheck
{
    public string ServiceName { get; }
    public string ServiceVersion { get; }
    public string ServiceDescription { get; }
    public Task<IHealthCheckServiceStatus> ReadinessHealthCheck(IRabbitMQConfiguration configurationRabbitMq, CancellationToken cancellationToken);
}
