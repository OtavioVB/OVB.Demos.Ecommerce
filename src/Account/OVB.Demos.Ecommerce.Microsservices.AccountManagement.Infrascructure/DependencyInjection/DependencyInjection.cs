using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.ReadinessCheck;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbInfrascructureConfiguration(this IServiceCollection serviceCollection, 
        string databaseConnectionString, string migrationsAssembly, string postgreeSqlServiceName, string postgreeSqlDescription, 
        string postgreeSqlServiceVersion)
    {
        serviceCollection.AddOvbRetryPoliciesConfiguration(TimeSpan.FromMilliseconds(50), 5);

        serviceCollection.AddDbContextPool<DataContext>(p => p.UseNpgsql(databaseConnectionString, p => p.MigrationsAssembly(migrationsAssembly)), 20);

        serviceCollection.AddScoped<IUnitOfWork, DefaultUnitOfWork>();

        serviceCollection.AddScoped<IBaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<BaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<IExtensionUserRepository, UserRepository>();

        serviceCollection.AddSingleton<IDatabaseHealthCheck, PostgreeSqlHealthCheck>(p =>
        {
            return new PostgreeSqlHealthCheck(postgreeSqlServiceName, postgreeSqlServiceVersion, postgreeSqlDescription, databaseConnectionString);
        });

        return serviceCollection;
    }
}
