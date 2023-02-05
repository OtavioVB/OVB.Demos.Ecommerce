using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbMessengerConfiguration(this IServiceCollection serviceCollection, string hostName, string virtualHost, string username, string password,
        string clientProviderName, int port)
    {
        serviceCollection.AddSingleton<IRabbitMQConnection, RabbitMQConnection>(p =>
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.VirtualHost = virtualHost;
            connectionFactory.UserName = username;
            connectionFactory.Password = password;
            connectionFactory.ClientProvidedName = clientProviderName;
            connectionFactory.HostName = hostName;
            connectionFactory.Port = port;
            return new RabbitMQConnection(connectionFactory.CreateConnection());
        });

        return serviceCollection;
    }
}
