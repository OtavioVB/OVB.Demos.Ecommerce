using MySql.Data.MySqlClient;
using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf;
using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsage;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsageConfiguration;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs.Protobuf;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories.Interfaces;
using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<IBaseDatabaseConnection<MySqlConnection>, DatabaseConnection>();
                services.AddSingleton<IBaseRepository<AccountProtobuf>, AccountRepository>();

                services.AddSingleton<ISerialization, Serialization>();
                services.AddSingleton<IAsyncConnectionFactory>(p =>
                {
                    return new ConnectionFactory()
                    {
                        HostName = "localhost",
                    };
                });
                services.AddSingleton<IFactoryMessengerConnection, FactoryMessengerConnection>();
                services.AddSingleton<IContainerMessengerConnection, ContainerMessengerConnection>();
                services.AddSingleton<IMessengerChannel, MessengerChannel>();
                services.AddSingleton<IMessengerSubscriber, MessengerSubscriber>();
                services.AddSingleton<IChannelUsageConfiguration>(p =>
                {
                    return new ChannelUsageConfiguration(p.GetService<IMessengerChannel>()!.GetChannel("Main")!);
                });
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}