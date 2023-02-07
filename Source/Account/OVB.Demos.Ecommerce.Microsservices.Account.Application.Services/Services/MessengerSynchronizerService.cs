using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services;

public sealed class MessengerSynchronizerService : IMessengerSynchronizerService<AccountProtobuf>
{
    private readonly IRabbitMQConnection _rabbitMQConnection;
    private readonly ITraceManager _traceManager;
    private readonly IRetry _retry;

    public MessengerSynchronizerService(
        IRabbitMQConnection rabbitMQConnection,
        ITraceManager traceManager,
        IRetry retry)
    {
        _rabbitMQConnection = rabbitMQConnection;
        _traceManager = traceManager;
        _retry = retry;
    }

    public Task PublishMessengerToSynchronizeDatabase(AccountProtobuf account)
    {
        return _traceManager.StartTracing("Publish Account To Messenger Synchronizer", System.Diagnostics.ActivityKind.Producer, async (activity) =>
        {
            return await _retry.TryRetry<bool, RabbitMQClientException>(() =>
            {
                var exchangeName = "ExchangeSynchronizeAccount";
                var queueName = "Synchronizer.Microsservices.Account.Subscriber";
                var routingKey = "Synchronizer.Microsservices.Account.*";
                _rabbitMQConnection.Model.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false);
                _rabbitMQConnection.Model.QueueDeclare(queueName, true, false, false);
                _rabbitMQConnection.Model.QueueBind(queueName, exchangeName, routingKey);
                _rabbitMQConnection.Model.BasicPublish(exchangeName, routingKey, null, Serializator.SerializeProtobuf(account));
                return Task.FromResult(true);
            });
        }, new Dictionary<string, string>()
            .AddKeyValue("TenantIdentifier", account.TenantIdentifier.ToString()!)
            .AddKeyValue("CorrelationIdentifier", account.CorrelationIdentifier.ToString()!)
            .AddKeyValue("SourcePlatform", account.SourcePlatform!));
    }
}
