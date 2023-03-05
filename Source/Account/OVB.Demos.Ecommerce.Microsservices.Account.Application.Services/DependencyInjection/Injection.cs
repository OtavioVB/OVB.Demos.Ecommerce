using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Adapters;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbApplicationServicesConfiguration(this IServiceCollection serviceCollection)
    {
        // Adapter
        serviceCollection.AddSingleton<IAdapter<AccountBase, AccountProtobuf>, AdapterAccountBaseToAccountProtobuf>();
        serviceCollection.AddSingleton<IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput>, AdapterCreateAccountUseCaseInputToServiceInput>();
        serviceCollection.AddSingleton<IAdapter<AccountBase, AccountDataTransfer>, AdapterAccountBaseToAccountDataTransfer>();

        // Retry
        serviceCollection.AddOvbRetryPoliciesConfiguration();

        // Services
        serviceCollection.AddScoped<IMessengerSynchronizerService<AccountProtobuf>, MessengerSynchronizerService>();
        serviceCollection.AddScoped<IAccountService, AccountService>();

        // UseCases
        serviceCollection.AddScoped<IUseCase<CreateAccountUseCaseInput>, CreateAccountUseCase>();

        return serviceCollection;
    }
}
