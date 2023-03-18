using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;

public interface IRabbitMQConfiguration
{
    public IModel GetChannel();
}
