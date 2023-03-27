using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOvbRabbitMQInfrascructureConfiguration(this IServiceCollection serviceCollection,
        string hostName, string virtualHost, int port, string clientProviderName, string userName, string password)
    {
        serviceCollection.AddSingleton<IRabbitMQConfiguration, RabbitMQConfiguration>((serviceProvider) =>
        {
            return new RabbitMQConfiguration(hostName, virtualHost, port, clientProviderName, userName, password);
        });

        serviceCollection.AddSingleton<IRabbitMQPublisher, RabbitMQPublisher>();

        return serviceCollection;
    }
}
