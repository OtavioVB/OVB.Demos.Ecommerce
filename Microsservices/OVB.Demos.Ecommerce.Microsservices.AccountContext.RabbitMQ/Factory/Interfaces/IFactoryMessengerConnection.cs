
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory.Interfaces;

public interface IFactoryMessengerConnection
{
    public IConnection GetMessengerConnection();
}
