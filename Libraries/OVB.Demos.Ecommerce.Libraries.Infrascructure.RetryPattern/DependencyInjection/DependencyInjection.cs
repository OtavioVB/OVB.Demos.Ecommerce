using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbRetryPoliciesConfiguration(this IServiceCollection serviceCollection, TimeSpan ratio, int numberOfRetries)
    {
        serviceCollection.AddScoped<IRetryConfiguration>((serviceProvider) =>
        {
            return new RetryConfiguration().SetTypeOfRetryEqualArithmeticProgression(ratio, TimeSpan.FromMilliseconds(150), numberOfRetries);
        });
        serviceCollection.AddScoped<IRetry, Retry>();

        return serviceCollection;
    }
}
