using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.CompilerServices;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber;

public sealed class MessengerSubscriber : IMessengerSubscriber
{
    private readonly IMessengerChannel _messengerChannel;
    private readonly ISerialization _serialization;

    public MessengerSubscriber(IMessengerChannel messengerChannel, ISerialization serialization)
    {
        _messengerChannel = messengerChannel;
        _serialization = serialization;
    }

    public void ConsumeMessage<TEntity>(string channelName, string queueName, Func<TEntity, Task> function)
        where TEntity : class
    {
        var channel = _messengerChannel.GetChannel(channelName);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();

            await function(_serialization.DeserializeUsingProtobuf<TEntity>(body));
            channel.BasicAck(ea.DeliveryTag, false);
        };
        channel.BasicConsume(queueName, false, consumer);
    }
}
