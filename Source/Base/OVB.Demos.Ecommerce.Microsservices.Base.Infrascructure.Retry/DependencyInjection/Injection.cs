using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbRetryPoliciesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRetryConfiguration>((serviceProvider) =>
        {
            return new RetryConfiguration().SetTypeOfRetryEqualArithmeticProgression(TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(150), 5);
        });
        serviceCollection.AddScoped<IRetry, Retry>();

        return serviceCollection;
    }
}
