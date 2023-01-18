using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsageConfiguration;

public interface IChannelUsageConfiguration
{
    public void DeclareExchangeChannelModelMode(string exchangeName, ExchangeTypes exchangeType, bool durable, bool autoDelete);
    public void BindExchangeWithChannel(string exchangeName, string queueName, string routingKey);
    public void DeclareRestrictionToSendMessageAtEachWorker(int prefetchSize, int prefetchCount, bool global);
    public void DeclareQueueModel(string queue, bool durable, bool exclusive, bool autoDelete);
    public IModel GetChannelConfigured();
}
