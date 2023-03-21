using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbInfrascructureHealthChecksConfiguration(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
