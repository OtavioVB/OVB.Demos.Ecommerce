using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher;

public sealed class MessengerPublisher : IMessengerPublisher
{
    private readonly IMessengerChannel _messengerChannel;
    private readonly ISerialization _serialization;

    public MessengerPublisher(IMessengerChannel messengerChannel, ISerialization serialization)
    {
        _serialization = serialization;
        _messengerChannel = messengerChannel;
    }

    public void PublishMessage(string channelName, string exchangeName, string routingKey, byte[] message)
    {
        var channel = _messengerChannel.GetChannel(channelName);

        channel.BasicPublish(exchangeName, routingKey, false, null, message);
    }

    public void PublishMessage(string channelName, string exchangeName, string routingKey, string message)
    {
        var channel = _messengerChannel.GetChannel(channelName);

        channel.BasicPublish(exchangeName, routingKey, false, null, _serialization.SerializeUsingProtobuf(message));
    }
}
