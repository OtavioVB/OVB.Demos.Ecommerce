using OVB.Demos.Ecommerce.Libraries.Domain.Serializator;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application;

public sealed class RabbitMqInsertUserConsumer : IRabbitMqInsertUserConsumer
{
    private readonly IRabbitMQConfiguration _rabbitMqConfiguration;
    private readonly IRabbitMQPublisher _rabbitMqPublisher;
    private readonly IUserRepository _userRepository;

    public RabbitMqInsertUserConsumer(
        IRabbitMQConfiguration rabbitMqConfiguration, 
        IRabbitMQPublisher rabbitMqPublisher, 
        IUserRepository userRepository)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
        _rabbitMqPublisher = rabbitMqPublisher;
        _userRepository = userRepository;
    }

    public Task CreateUserWithConsumerAsync()
    {
        var channel = _rabbitMqConfiguration.GetChannel();
        channel.QueueDeclare("AccountMicrosservice.Synchronizer.User.Insert.Queue", true, false, false, null);
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += async (component, basicDeliverEventArgs) =>
        {
                var body = basicDeliverEventArgs.Body;
                var userProtobuffer = Serializator.DeserializeProtobuf<UserProtobuffer>(body.ToArray());
                await _userRepository.AddUserAsync(userProtobuffer);
                _rabbitMqPublisher.BasicAck(basicDeliverEventArgs.DeliveryTag, false);
        };

        return Task.FromResult(channel.BasicConsume("AccountMicrosservice.Synchronizer.User.Insert.Queue", false, consumer));
    }
}
