using OVB.Demos.Ecommerce.Libraries.Domain.Serializator;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Properties;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext;

public sealed class MessengerSynchronizerService : IMessengerSynchronizerService
{
    private readonly IRabbitMQPublisher _rabbitMqPublisher;
    private readonly IRetry _retry;

    public MessengerSynchronizerService(
        IRabbitMQPublisher rabbitMqPublisher,
        IRetry retry)
    {
        _rabbitMqPublisher = rabbitMqPublisher;
        _retry = retry;
    }

    public Task PublishMessageToBusToSynchronizeDatabaseWithInsert(UserProtobuffer user, Guid correlationIdentifier, Guid tenantIdentifier, string sourcePlatform,
        CancellationToken cancellationToken)
    {
        return _retry.TryRetryWithCircuitBreaker<Task, RabbitMQClientException>(() =>
        {
            return Task.Run(() =>
            {
                var userSerialized = Serializator.SerializeProtobuf(user);

                const ExchangeTypes exchangeType = ExchangeTypes.Topic;
                const string exchangeName = "ExchangeSynchronizerAccountMicrosservice";
                const string routingKey = "AccountMicrosservice.Synchronizer.User.Insert.*";
                const string queueName = "AccountMicrosservice.Synchronizer.User.Insert.Queue";
                _rabbitMqPublisher.ExchangeDeclare(exchangeName, exchangeType, true, false);
                _rabbitMqPublisher.QueueDeclare(queueName, true, false, false);
                _rabbitMqPublisher.QueueBindDeclare(queueName, exchangeName, routingKey);
                _rabbitMqPublisher.PublishExchange(exchangeName, routingKey, userSerialized);
            });
        }, cancellationToken);
    }
}
