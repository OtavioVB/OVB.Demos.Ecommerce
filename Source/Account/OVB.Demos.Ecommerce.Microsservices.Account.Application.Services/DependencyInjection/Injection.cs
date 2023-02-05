using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbApplicationServicesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMessengerSynchronizerService<AccountProtobuf>, MessengerSynchronizerService>();

        return serviceCollection;
    }
}
