using OVB.Demos.Ecommerce.Libraries.Domain.Serializator;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Properties;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext;

public sealed class MessengerSynchronizerService : IMessengerSynchronizerService
{
    private readonly IRabbitMQPublisher _rabbitMqPublisher;

    public MessengerSynchronizerService(IRabbitMQPublisher rabbitMqPublisher)
    {
        _rabbitMqPublisher = rabbitMqPublisher;
    }

    public Task PublishMessageToBusToSynchronizeDatabaseWithInsert(UserProtobuffer user, Guid correlationIdentifier, string sourcePlatform)
    {
        return Task.FromResult(() =>
        {
            var userSerialized = Serializator.SerializeProtobuf(user);

            const ExchangeTypes exchangeType = ExchangeTypes.Direct;
            const string exchangeName = "AccountMicrosservice.Synchronizer";
            const string routingKey = "AccountMicrosservice.Synchronizer.User.Insert";
            const string queueName = "AccountMicrosservice.Synchronizer.User.Insert.Queue";
            _rabbitMqPublisher.ExchangeDeclare(exchangeName, ExchangeTypes.Direct, true, false, null);
            _rabbitMqPublisher.QueueDeclare(queueName, true, false, false, null);
            _rabbitMqPublisher.QueueBindDeclare(queueName, exchangeName, routingKey, new Dictionary<string, object>());
            _rabbitMqPublisher.PublishQueue(queueName, new BasicProperties(exchangeType.ToString(), exchangeName, routingKey)
            {
                CorrelationId = correlationIdentifier.ToString(),
                AppId = sourcePlatform
            }, userSerialized);
        });
    }
}
