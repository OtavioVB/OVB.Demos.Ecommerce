namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher.Interfaces;

public interface IMessengerPublisher
{
    public void PublishMessage(string channelName, string exchangeName, string routingKey, byte[] message);
    public void PublishMessage(string channelName, string exchangeName, string routingKey, string message);
}
