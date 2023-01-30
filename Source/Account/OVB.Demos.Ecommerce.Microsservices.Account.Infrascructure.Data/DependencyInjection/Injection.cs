using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbInfrascructureConfiguration(this IServiceCollection serviceCollection, 
        string postgreeSqlConnection, string migrationsAssembly)
    {
        serviceCollection.AddDbContextPool<DataContext>(p => p.UseNpgsql(postgreeSqlConnection, 
            p => p.MigrationsAssembly(migrationsAssembly)), 20);

        return serviceCollection;
    }
}
