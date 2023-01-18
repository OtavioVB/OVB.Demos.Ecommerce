namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi.HealthCheck.Models;

public class HealthCheckModel
{
    public HealthCheckModel(string serviceName, bool isHealthy)
    {
        ServiceName = serviceName;
        IsHealthy = isHealthy;
    }

    public string ServiceName { get; set; }
    public bool IsHealthy { get; set; } 
}
