using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsageConfiguration;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsage;

public sealed class ChannelUsageConfiguration : IChannelUsageConfiguration
{
    private IModel _channelModel;

    public ChannelUsageConfiguration(IModel channelModel)
    {
        _channelModel = channelModel;
    }

    /// <summary>
    /// Create Exchange Mode According to Channel
    /// </summary>
    /// <param name="exchangeName">Name of Exchange</param>
    /// <param name="exchangeType">The type of Exchange: Fanout, Topic, Headers, Direct</param>
    /// <param name="durable">Enable the queue stay open after server restart.</param>
    /// <param name="autoDelete">Delete automatically after queue is consumed</param>
    public void DeclareExchangeChannelModelMode(string exchangeName, ExchangeTypes exchangeType, bool durable, bool autoDelete)
    {
        _channelModel.ExchangeDeclare(exchangeName, exchangeType.ToString(), durable, autoDelete, null);
    }

    public void BindExchangeWithChannel(string exchangeName, string queueName, string routingKey)
    {
        _channelModel.QueueBind(queueName, exchangeName, routingKey);
    }

    public void DeclareRestrictionToSendMessageAtEachWorker(int prefetchSize, int prefetchCount, bool global)
    {
        _channelModel.BasicQos((uint)prefetchSize, (ushort)prefetchCount, global);
    }

    /// <summary>
    /// Declare Queue According to respective necessity
    /// </summary>
    /// <param name="queue">The name of Queue.</param>
    /// <param name="durable">Enable the queue stay open after server restart.</param>
    /// <param name="exclusive">The queue is used only in this connection.</param>
    /// <param name="autoDelete">Delete automatically after queue is consumed</param>
    public void DeclareQueueModel(string queue, bool durable, bool exclusive, bool autoDelete)
    {
        _channelModel.QueueDeclare(queue, durable, exclusive, autoDelete, null);
    }

    public IModel GetChannelConfigured()
    {
        return _channelModel;
    }
}
