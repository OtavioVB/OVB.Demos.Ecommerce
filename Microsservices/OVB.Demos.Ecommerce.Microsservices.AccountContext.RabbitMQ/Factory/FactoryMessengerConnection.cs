using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory;

public sealed class FactoryMessengerConnection : IFactoryMessengerConnection
{
    private IAsyncConnectionFactory _connectionFactory;

    public FactoryMessengerConnection(IAsyncConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public IConnection GetMessengerConnection()
    {
        return _connectionFactory.CreateConnection();
    }
}
