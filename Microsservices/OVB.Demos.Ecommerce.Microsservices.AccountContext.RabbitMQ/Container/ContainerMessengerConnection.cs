using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container;

public sealed class ContainerMessengerConnection : IContainerMessengerConnection
{
    private IFactoryMessengerConnection _rabbitMqFactoryConnection;
    private IConnection _connection;

    public ContainerMessengerConnection(IFactoryMessengerConnection rabbitMqConnection)
    {
        _rabbitMqFactoryConnection = rabbitMqConnection;
        _connection = _rabbitMqFactoryConnection.GetMessengerConnection();
    }

    public IModel CreateChannel()
    {
        return _connection.CreateModel();
    }
}
