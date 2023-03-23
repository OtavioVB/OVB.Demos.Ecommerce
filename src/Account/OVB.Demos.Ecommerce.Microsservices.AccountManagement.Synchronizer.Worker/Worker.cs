using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker;

public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await new UserRepository(new DataConnection("User Id=admin;Password=1234;Server=localhost;Port=5433;Database=ovbdemosecommerce")).CreateTableUserIfThisNotExists();
            await Task.Delay(1000, stoppingToken);
        }
    }
}