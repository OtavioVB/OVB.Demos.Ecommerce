using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel;

public sealed class MessengerChannel : IMessengerChannel
{
    private IContainerMessengerConnection _containerMessengerConnection;
    private IDictionary<string, IModel> _modelChannel;

    public MessengerChannel(
        IContainerMessengerConnection containerMessengerConnection)
    {
        _containerMessengerConnection = containerMessengerConnection;
        _modelChannel = new Dictionary<string, IModel>();
        CreateChannel("Main");
    }

    public void CreateChannel(string channelName)
    {
        if (_modelChannel.ContainsKey(channelName))
            return;

        _modelChannel.Add(channelName, _containerMessengerConnection.CreateChannel());
    }

    public void RemoveChannel(string channelName)
    {
        if (_modelChannel.Keys.Contains(channelName) == false)
            return;

        _modelChannel.Remove(channelName);
    }

    public IModel GetChannel(string channelName)
    {
        if (_modelChannel.Keys.Contains(channelName) == false)
            throw new Exception("Is not possible to get the RabbitMQ by its Key Channel Name.");

        return _modelChannel[channelName];
    }
}