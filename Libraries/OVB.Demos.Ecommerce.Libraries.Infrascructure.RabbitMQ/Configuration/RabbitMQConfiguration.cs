using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Exceptions;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration;

public sealed class RabbitMQConfiguration : IRabbitMQConfiguration
{
    private IConnection? RabbitMQConnection { get; set; }
    private IModel? RabbitMQChannel { get; set; }

    public RabbitMQConfiguration(string hostName, string virtualHost, int port, string clientProviderName, string userName, string password)
    {
        var factory = new ConnectionFactory()
        {
            Port = port,
            HostName = hostName,
            VirtualHost = virtualHost,
            UserName = userName,
            ClientProvidedName = clientProviderName,
            Password = password,
        };
        RabbitMQConnection = factory.CreateConnection();
        RabbitMQChannel = RabbitMQConnection.CreateModel();
    }

    public IModel GetChannel()
    {
        if (RabbitMQChannel is null)
            throw new OvbRabbitMQException("The RabbitMQ connection and RabbitMQ channel needs to be configured correctly.");

        return RabbitMQChannel;
    }
}
