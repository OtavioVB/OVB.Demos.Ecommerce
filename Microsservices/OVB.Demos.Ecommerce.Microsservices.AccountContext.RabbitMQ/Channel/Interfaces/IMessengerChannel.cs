using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel.Interfaces;

public interface IMessengerChannel
{
    public void CreateChannel(string channelName);
    public void RemoveChannel(string channelName);
    public IModel GetChannel(string channelName);
}
