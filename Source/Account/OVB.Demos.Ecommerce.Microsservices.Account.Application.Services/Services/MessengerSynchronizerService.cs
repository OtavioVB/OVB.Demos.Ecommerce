using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.RabbitConnection.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services;

public sealed class MessengerSynchronizerService : IMessengerSynchronizerService<AccountProtobuf>
{
    private readonly IRabbitMQConnection _rabbitMQConnection;

    public MessengerSynchronizerService(IRabbitMQConnection rabbitMQConnection)
    {
        _rabbitMQConnection = rabbitMQConnection;
    }

    public void PublishMessengerToSynchronizeDatabase(AccountProtobuf account)
    {
        var exchangeName = "ExchangeSynchronizeAccount";
        var queueName = "SynchronizerAccount";
        var routingKey = "Synchronizer.Microsservices.Account.*";
        _rabbitMQConnection.Model.ExchangeDeclare(exchangeName, ExchangeType.Topic, true, false);
        _rabbitMQConnection.Model.QueueDeclare(queueName, true, false, false);
        _rabbitMQConnection.Model.QueueBind(queueName, exchangeName, routingKey);
        _rabbitMQConnection.Model.BasicPublish(queueName, "Synchronizer.Microsservices.Account.Publisher", null, Serializator.SerializeProtobuf(account));
    }
}
