using Npgsql;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.Interfaces.Inputs.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.ReadinessCheck;

public sealed class PostgreeSqlHealthCheck : IDatabaseHealthCheck
{
    public string ServiceName { get; init; }
    public string ServiceVersion { get; init; }
    public string ServiceDescription { get; init; }
    public string ServiceConnectionString { get; init; }

    public PostgreeSqlHealthCheck(string serviceName, string serviceVersion, string serviceDescription, string serviceConnectionString)
    {
        ServiceName = serviceName;
        ServiceVersion = serviceVersion;
        ServiceDescription = serviceDescription;
        ServiceConnectionString = serviceConnectionString;
    }

    public async Task<IHealthCheckServiceStatus> ReadinessHealthCheck(CancellationToken cancellationToken)
    {
        var connection = new NpgsqlConnection(ServiceConnectionString);

        try
        {
            await connection.OpenAsync();
            return new HealthCheckServiceStatus(ServiceName, ServiceVersion, ServiceDescription, HealthCheckStatus.Healthy);
        }
        catch
        {
            return new HealthCheckServiceStatus(ServiceName, ServiceVersion, ServiceDescription, HealthCheckStatus.Unhealthy);
        }
    }
}
