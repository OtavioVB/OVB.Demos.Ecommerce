using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbInfrascructureConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<BaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<IExtensionUserRepository, UserRepository>();

        return serviceCollection;
    }
}
