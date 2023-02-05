using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection;

public sealed class RabbitMQConnection : IRabbitMQConnection
{
    public IModel Model { get; private set; }
    public IConnection Connection { get; private set; }

    public RabbitMQConnection(IConnection connection)
    {
        Model = connection.CreateModel();
        Connection = connection;
    }
}
