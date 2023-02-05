using Npgsql;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Interfaces;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbDefaultDatabaseConfiguration(this IServiceCollection serviceCollection, string defaultStringConnection)
    {
        serviceCollection.AddSingleton<IDataConnection<NpgsqlCommand>, DataConnection>(p =>
        {
            return new DataConnection(new NpgsqlConnection(defaultStringConnection));
        });

        serviceCollection.AddSingleton<IBaseRepository<AccountDataTransfer>, AccountRepository>();

        return serviceCollection;
    }
}
