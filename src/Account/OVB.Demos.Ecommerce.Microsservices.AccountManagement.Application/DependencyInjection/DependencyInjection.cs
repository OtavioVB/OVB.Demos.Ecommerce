using Microsoft.Extensions.DependencyInjection;
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
        serviceCollection.AddScoped<IUserService, UserService>();

        serviceCollection.AddScoped<IUseCase<CreateUserUseCaseInput, CreateUserUseCaseOutput>, CreateUserUseCase>();

        return serviceCollection;
    }
}
