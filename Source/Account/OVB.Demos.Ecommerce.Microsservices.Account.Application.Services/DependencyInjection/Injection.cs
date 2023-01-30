using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbApplicationServicesConfiguration(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
