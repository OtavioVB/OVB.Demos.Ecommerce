using OVB.Demos.Ecommerce.Libraries.Domain.Serializator;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Publishers.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker;

public class WorkerAddUser : BackgroundService
{
    private readonly IRabbitMQConfiguration _rabbitMqConfiguration;
    private readonly IRabbitMQPublisher _rabbitMqPublisher;
    private readonly IUserRepository _userRepository;

    public WorkerAddUser(IRabbitMQConfiguration rabbitMqConfiguration, IRabbitMQPublisher rabbitMqPublisher, IUserRepository userRepository)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
        _rabbitMqPublisher = rabbitMqPublisher;
        _userRepository = userRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _userRepository.CreateTableUserIfThisNotExists();
        var channel = _rabbitMqConfiguration.GetChannel();
        _rabbitMqPublisher.QueueDeclare("AccountMicrosservice.Synchronizer.User.Insert.Queue", true, false, false);
        var consumer = new EventingBasicConsumer(channel);
        while (!stoppingToken.IsCancellationRequested)
        {
            consumer.Received += async (component, basicDeliverEventArgs) =>
            {
                try
                {
                    var body = basicDeliverEventArgs.Body;
                    var userProtobuffer = Serializator.DeserializeProtobuf<UserProtobuffer>(body.ToArray());
                    await _userRepository.AddUserAsync(userProtobuffer);
                    _rabbitMqPublisher.BasicAck(basicDeliverEventArgs.DeliveryTag, false);
                }
                catch
                {
                    _rabbitMqPublisher.BasicNack(basicDeliverEventArgs.DeliveryTag, false, true);
                }
            };

            channel.BasicConsume("AccountMicrosservice.Synchronizer.User.Insert.Queue", false, consumer);
            await Task.Delay(1000, stoppingToken);
        }
    }
}   