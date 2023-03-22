using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.HealthChecks;
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
        string postgreeSqlServiceVersion, string rabbitMqHostname, string rabbitMqVirtualhost, int rabbitMqPort, string rabbitMqClientProviderName,
        string rabbitMqUsername, string rabbitMqPassword, string rabbitMqServiceName, string rabbitMqServiceVersion, string rabbitMqServiceDescription)
    {
        serviceCollection.AddOvbRetryPoliciesConfiguration(TimeSpan.FromMilliseconds(50), 5);

        serviceCollection.AddOvbRabbitMQInfrascructureConfiguration(rabbitMqHostname, rabbitMqVirtualhost, rabbitMqPort, rabbitMqClientProviderName, rabbitMqUsername,
            rabbitMqPassword);

        serviceCollection.AddDbContextPool<DataContext>(p => p.UseNpgsql(databaseConnectionString, p => p.MigrationsAssembly(migrationsAssembly)), 20);

        serviceCollection.AddScoped<IUnitOfWork, DefaultUnitOfWork>();

        serviceCollection.AddScoped<IBaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<BaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<IExtensionUserRepository, UserRepository>();

        serviceCollection.AddSingleton<IDependencyHealthCheck, PostgreeSqlHealthCheck>(p =>
        {
            return new PostgreeSqlHealthCheck(postgreeSqlServiceName, postgreeSqlServiceVersion, postgreeSqlDescription, databaseConnectionString);
        });

        serviceCollection.AddSingleton<IRabbitMqHealthCheck, RabbitMqHealthCheck>(p =>
        {
            return new RabbitMqHealthCheck(rabbitMqServiceName, rabbitMqServiceVersion, rabbitMqServiceDescription);
        });

        return serviceCollection;
    }
}
