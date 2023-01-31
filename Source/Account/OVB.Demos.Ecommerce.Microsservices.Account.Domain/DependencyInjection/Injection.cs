using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbDomainConfiguration(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
