using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer;

public sealed class RabbitMQConsumer : IRabbitMQConsumer
{
    private readonly IRabbitMQConnection _rabbitMqConnection;

    public RabbitMQConsumer(IRabbitMQConnection rabbitMqConnection)
    {
        _rabbitMqConnection = rabbitMqConnection;
    }

    public void ConsumeMessage(Func<byte[], Task<bool>> handler)
    {
        _rabbitMqConnection.Model.QueueDeclare("Synchronizer.Microsservices.Account.Subscriber", true, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(_rabbitMqConnection.Model);
        consumer.Received += async (model, ea) =>
        {
            var handlerResult = await handler(ea.Body.ToArray());

            if (handlerResult == true)
                _rabbitMqConnection.Model.BasicAck(ea.DeliveryTag, multiple: false);
            else
                _rabbitMqConnection.Model.BasicNack(ea.DeliveryTag, multiple: false, requeue: true);
        };

        _rabbitMqConnection.Model.BasicConsume("Synchronizer.Microsservices.Account.Subscriber", false, consumer);
    }
}
