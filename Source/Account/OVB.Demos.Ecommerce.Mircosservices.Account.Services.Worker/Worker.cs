using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConsumer.Interfaces;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker;

public class Worker : BackgroundService
{
    private readonly IRabbitMQConsumer _rabbitMQConsumer;
    private readonly IBaseRepository<AccountDataTransfer> _baseRepositoryAccountBase;
    private readonly IAdapter<AccountProtobuf, AccountDataTransfer> _adapterAccountProtobufToAccountBase;
    private readonly ITraceManager _traceManager;

    public Worker(
        IRabbitMQConsumer rabbitMQConsumer, 
        IBaseRepository<AccountDataTransfer> baseRepositoryAccountBase, 
        IAdapter<AccountProtobuf, AccountDataTransfer> adapterAccountProtobufToAccountBase,
        ITraceManager traceManager)
    {
        _rabbitMQConsumer = rabbitMQConsumer;
        _baseRepositoryAccountBase = baseRepositoryAccountBase;
        _adapterAccountProtobufToAccountBase = adapterAccountProtobufToAccountBase;
        _traceManager = traceManager;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var deliveryTags = new Dictionary<string, string>();
            _traceManager.StartTracing("Worker Create Account Service", ActivityKind.Consumer, async (activity) =>
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
            }, deliveryTags);
        }
    }
}