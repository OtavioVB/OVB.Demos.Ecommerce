using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer.Interfaces;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker;

public class Worker : BackgroundService
{
    private readonly IRabbitMQConsumer _rabbitMQConsumer;
    private readonly IBaseRepository<AccountDataTransfer> _baseRepositoryAccountBase;
    private readonly IAdapter<AccountProtobuf, AccountDataTransfer> _adapterAccountProtobufToAccountBase;

    public Worker(
        IRabbitMQConsumer rabbitMQConsumer, 
        IBaseRepository<AccountDataTransfer> baseRepositoryAccountBase, 
        IAdapter<AccountProtobuf, AccountDataTransfer> adapterAccountProtobufToAccountBase)
    {
        _rabbitMQConsumer = rabbitMQConsumer;
        _baseRepositoryAccountBase = baseRepositoryAccountBase;
        _adapterAccountProtobufToAccountBase = adapterAccountProtobufToAccountBase;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _rabbitMQConsumer.ConsumeMessage(async (information) =>
            {
                try
                {
                    var accountProtobuf = Serializator.DeserializeProtobuf<AccountProtobuf>(information);
                    await _baseRepositoryAccountBase.AddEntityAsync(_adapterAccountProtobufToAccountBase.Adapter(accountProtobuf));
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}