using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.ENUMs;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;

public interface IRabbitMQPublisher
{
    public void PublishQueue(string queueName, IBasicProperties basicProperties, ReadOnlyMemory<byte> message);
    public void PublishExchange(string exchangeName, string routingKey, ReadOnlyMemory<byte> message, IBasicProperties? basicProperties = null);
    public void QueueDeclare(string queue, bool isDurable, bool exclusive, bool autoDelete, IDictionary<string, object>? arguments = null);
    public void ExchangeDeclare(string exchange, ExchangeTypes type, bool isDurable, bool autoDelete, IDictionary<string, object>? arguments = null);
    public void QueueBindDeclare(string queue, string exchange, string routingKey);
    public void BasicAck(ulong deliveryTag, bool isMultiple);
    public void BasicNack(ulong deliveryTag, bool isMultiple, bool requeue);
}
