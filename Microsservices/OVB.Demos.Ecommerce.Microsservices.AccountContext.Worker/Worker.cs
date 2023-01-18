using MySql.Data.MySqlClient;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs.Protobuf;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker;

public class Worker : BackgroundService
{
    private readonly IMessengerSubscriber _messengerSubscriber;
    private readonly IBaseRepository<AccountProtobuf> _accountBaseRepository;
    private readonly IBaseDatabaseConnection<MySqlConnection> _baseDatabaseConnection;

    public Worker(IMessengerSubscriber messengerSubscriber, IBaseRepository<AccountProtobuf> accountBaseRepository,
        IBaseDatabaseConnection<MySqlConnection> baseDatabaseConnection)
    {
        _messengerSubscriber = messengerSubscriber;
        _accountBaseRepository = accountBaseRepository;
        _baseDatabaseConnection = baseDatabaseConnection;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _messengerSubscriber.ConsumeMessage<AccountProtobuf>("Main", "Microsservices.Account.Created", async (p) =>
                {
                    await _accountBaseRepository.AddEntityAsync(p);
                });
            }
            catch
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}