using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services;

public sealed class MessengerSynchronizerService : IMessengerSynchronizerService<AccountProtobuf>
{
    private readonly IRabbitMQConnection _rabbitMQConnection;
    private readonly ITraceManager _traceManager;

    public MessengerSynchronizerService(
        IRabbitMQConnection rabbitMQConnection,
        ITraceManager traceManager)
    {
        _rabbitMQConnection = rabbitMQConnection;
        _traceManager = traceManager;
    }

    public Task PublishMessengerToSynchronizeDatabase(AccountProtobuf account)
    {
        var traceManagerTags = new Dictionary<string, string>();
        traceManagerTags.Add("TenantIdentifier", account.ToString()!);
        traceManagerTags.Add("CorrelationIdentifier", account.ToString()!);
        traceManagerTags.Add("SourcePlatform", account.SourcePlatform!);
        return Task.FromResult(_traceManager.StartTracing("Publish Account To Messenger Synchronizer", System.Diagnostics.ActivityKind.Producer, (activity) =>
        {
            return Task.Run(() =>
            {
                var exchangeName = "ExchangeSynchronizeAccount";
                var queueName = "Synchronizer.Microsservices.Account.Subscriber";
                var routingKey = "Synchronizer.Microsservices.Account.*";
                _rabbitMQConnection.Model.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false);
                _rabbitMQConnection.Model.QueueDeclare(queueName, true, false, false);
                _rabbitMQConnection.Model.QueueBind(queueName, exchangeName, routingKey);
                _rabbitMQConnection.Model.BasicPublish(exchangeName, routingKey, null, Serializator.SerializeProtobuf(account));
            });
        }, traceManagerTags));
    }
}
