namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber.Interfaces;

public interface IMessengerSubscriber
{
    public void ConsumeMessage<TEntity>(string channelName, string queueName, Func<TEntity, Task> function)
        where TEntity : class;
}
