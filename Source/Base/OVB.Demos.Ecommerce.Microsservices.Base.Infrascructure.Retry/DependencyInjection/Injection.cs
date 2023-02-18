using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbRetryPoliciesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IRetryConfiguration, RetryConfiguration>();
        serviceCollection.AddSingleton<IRetry, Retry>();

        return serviceCollection;
    }
}
