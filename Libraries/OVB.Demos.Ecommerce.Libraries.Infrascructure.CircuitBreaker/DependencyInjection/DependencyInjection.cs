using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbCircuitBreakerResiliencePolicyConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICircuitBreakerConfiguration, CircuitBreakerConfiguration>();
        serviceCollection.AddSingleton<ICircuitBreakerFunctions, CircuitBreakerFunctions>();

        return serviceCollection;
    }
}
