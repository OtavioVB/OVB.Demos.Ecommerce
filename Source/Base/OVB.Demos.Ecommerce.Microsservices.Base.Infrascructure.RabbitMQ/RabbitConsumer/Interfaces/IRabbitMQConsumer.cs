namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer.Interfaces;

public interface IRabbitMQConsumer
{
    public Task ConsumeMessage(Func<byte[], Task<bool>> handler);
}
