using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Outputs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbAccountManagementMicrosserviceApplicationConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOvbCircuitBreakerResiliencePolicyConfiguration()
            .AddCircuitBreakerPolicy<NpgsqlException>("Npgsql", 1, TimeSpan.FromMilliseconds(1500))
            .AddCircuitBreakerPolicy<PostgresException>("Postgres", 1, TimeSpan.FromMilliseconds(1500));

        serviceCollection.AddScoped<IUserService, UserService>();

        serviceCollection.AddScoped<IMessengerSynchronizerService, MessengerSynchronizerService>();

        serviceCollection.AddScoped<IUseCase<CreateUserUseCaseInput, CreateUserUseCaseOutput>, CreateUserUseCase>();

        return serviceCollection;
    }
}
