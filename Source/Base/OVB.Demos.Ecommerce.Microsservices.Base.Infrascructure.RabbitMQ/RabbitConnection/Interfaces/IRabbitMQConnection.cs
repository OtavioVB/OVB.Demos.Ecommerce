using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;

public interface IRabbitMQConnection
{
    public IModel Model { get; }
    public IConnection Connection { get; }
}
