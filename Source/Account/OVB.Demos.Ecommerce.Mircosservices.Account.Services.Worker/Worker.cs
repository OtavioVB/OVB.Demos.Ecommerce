using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker;

public class Worker : BackgroundService
{
    private readonly IRabbitMQConsumer _rabbitMQConsumer;

    public Worker(IRabbitMQConsumer rabbitMQConsumer)
    {
        _rabbitMQConsumer = rabbitMQConsumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _rabbitMQConsumer.ConsumeMessage(async (information) =>
            {
                await Task.Delay(10000);
                return await Task.FromResult(true);
            });
        }
    }
}