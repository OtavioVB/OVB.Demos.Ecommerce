using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Domain.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbDomainAccountManagementMicrosserviceConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDomainValidatorsConfiguration();

        serviceCollection.AddSingleton<IUserBuilder, UserBuilder>();

        return serviceCollection;
    }
}
