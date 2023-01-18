using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container.Interfaces;

public interface IContainerMessengerConnection
{
    public IModel CreateChannel();
}
