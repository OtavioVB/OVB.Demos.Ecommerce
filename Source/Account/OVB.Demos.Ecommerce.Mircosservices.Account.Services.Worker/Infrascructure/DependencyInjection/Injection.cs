using Npgsql;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbDefaultDatabaseConfiguration(this IServiceCollection serviceCollection, string defaultStringConnection)
    {
        serviceCollection.AddTransient<IBaseRepository<AccountDataTransfer>, AccountRepository>(p =>
        {
            return new AccountRepository(new NpgsqlConnection(defaultStringConnection));
        });

        return serviceCollection;
    }
}
