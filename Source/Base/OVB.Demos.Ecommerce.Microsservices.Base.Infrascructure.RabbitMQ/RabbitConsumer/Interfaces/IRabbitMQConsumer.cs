namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer.Interfaces;

public interface IRabbitMQConsumer
{
    public void ConsumeMessage(Func<byte[], Task<bool>> handler);
}
