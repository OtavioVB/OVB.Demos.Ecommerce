using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker;

public class WorkerAddUser : BackgroundService
{
    private readonly IRabbitMqInsertUserConsumer _rabbitMqInserUserConsumer;
    private readonly IUserRepository _userRepository;

    public WorkerAddUser(
        IRabbitMqInsertUserConsumer rabbitMqInserUserConsumer,
        IUserRepository userRepository)
    {
        _rabbitMqInserUserConsumer = rabbitMqInserUserConsumer;
        _userRepository = userRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _userRepository.CreateTableUserIfThisNotExists();
        while (!stoppingToken.IsCancellationRequested)
        {
            await _rabbitMqInserUserConsumer.CreateUserWithConsumerAsync();
            await Task.Delay(1000, stoppingToken);
        }
    }
}