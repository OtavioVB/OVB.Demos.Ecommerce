using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker;

public class WorkerAddUser : BackgroundService
{
    private readonly IRabbitMqInsertUserConsumer _rabbitMqInserUserConsumer;

    public WorkerAddUser(IRabbitMqInsertUserConsumer rabbitMqInserUserConsumer)
    {
        _rabbitMqInserUserConsumer = rabbitMqInserUserConsumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _rabbitMqInserUserConsumer.CreateUserWithConsumerAsync();
            await Task.Delay(1000, stoppingToken);
        }
    }
}