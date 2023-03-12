using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbApplicationConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();

        return serviceCollection;
    }
}
