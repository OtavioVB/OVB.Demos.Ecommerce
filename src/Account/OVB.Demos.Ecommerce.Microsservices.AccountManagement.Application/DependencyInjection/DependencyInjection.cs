using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbAccountManagementMicrosserviceApplicationConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();

        return serviceCollection;
    }
}
