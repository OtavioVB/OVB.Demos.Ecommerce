using Npgsql;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbDefaultDatabaseConfiguration(this IServiceCollection serviceCollection, string defaultStringConnection)
    {
        serviceCollection.AddSingleton<IDataConnection<NpgsqlCommand>, DataConnection>(p =>
        {
            return new DataConnection(new NpgsqlConnection(defaultStringConnection));
        });

        return serviceCollection;
    }
}
