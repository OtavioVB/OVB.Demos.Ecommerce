using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers;

public sealed class RabbitMQPublisher : IRabbitMQPublisher
{
    private readonly IRabbitMQConfiguration _rabbitMQConfiguration;

    public RabbitMQPublisher(IRabbitMQConfiguration rabbitMQConfiguration)
    {
        _rabbitMQConfiguration = rabbitMQConfiguration;
    }

    public void PublishQueue(string queueName, IBasicProperties basicProperties, ReadOnlyMemory<byte> message)
    {
        var channel = _rabbitMQConfiguration.GetChannel();

        lock (channel)
        {
            channel.BasicPublish(null, queueName, basicProperties, message);
        }
    }

    public void PublishExchange(string exchangeName, string routingKey, IBasicProperties basicProperties, ReadOnlyMemory<byte> message)
    {
        var channel = _rabbitMQConfiguration.GetChannel();

        lock (channel)
        {
            channel.BasicPublish(exchangeName, routingKey, basicProperties, message);
        }
    } 

    public void QueueDeclare(string queue, bool isDurable, bool exclusive, bool autoDelete, IDictionary<string, object>? arguments = null)
    {
        var channel = _rabbitMQConfiguration.GetChannel();
        channel.QueueDeclare(queue, isDurable, exclusive, autoDelete, arguments);
    }

    public void ExchangeDeclare(string exchange, ExchangeTypes type, bool isDurable, bool autoDelete, IDictionary<string, object>? arguments = null)
    {
        var channel = _rabbitMQConfiguration.GetChannel();
        channel.ExchangeDeclare(exchange, type switch
        {
            ExchangeTypes.Topic => ExchangeType.Topic,
            ExchangeTypes.Direct => ExchangeType.Direct,
            ExchangeTypes.Fanout => ExchangeType.Fanout,
            ExchangeTypes.Headers => ExchangeType.Headers,
            _ => throw new InvalidOperationException("The exchange type needs to be valid.")
        }, isDurable, autoDelete, arguments);
    }

    public void QueueBindDeclare(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
    {
        var channel = _rabbitMQConfiguration.GetChannel();
        channel.QueueBind(queue, exchange, routingKey, arguments);
    }

    public void BasicAck(ulong deliveryTag, bool isMultiple)
    {
        var channel = _rabbitMQConfiguration.GetChannel();
        channel.BasicAck(deliveryTag, isMultiple);
    }

    public void BasicNack(ulong deliveryTag, bool isMultiple, bool requeue)
    {
        var channel = _rabbitMQConfiguration.GetChannel();
        channel.BasicNack(deliveryTag, isMultiple, requeue);
    }
}
