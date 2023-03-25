using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Application.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                var databaseConnectionString = hostContext.Configuration["Infrascructure:Databases:PostgreeSQL:ConnectionString"];
                var rabbitMqVirtualhost = hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Virtualhost"];
                var rabbitMqHostname = hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Hostname"];
                var rabbitMqUsername = hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Username"];
                var rabbitMqPort = hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Port"];
                var rabbitMqPassword = hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Password"];
                var rabbitMqClientProviderName = hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:ClientProviderName"];

                if (databaseConnectionString is null)
                    throw new Exception("Database connection string cannot be null.");

                if (rabbitMqVirtualhost is null)
                    throw new Exception("Is not possible to configure and check the rabbit mq messenger with virtual host being null.");

                if (rabbitMqHostname is null)
                    throw new Exception("Is not possible to configure and check the rabbit mq messenger with hostname being null.");

                if (rabbitMqUsername is null)
                    throw new Exception("Is not possible to configure and check the rabbit mq messenger with username being null.");

                if (rabbitMqPort is null)
                    throw new Exception("Is not possible to configure and check the rabbit mq messenger with port being null.");

                if (rabbitMqPassword is null)
                    throw new Exception("Is not possible to configure and check the rabbit mq messenger with password being null.");

                if (rabbitMqClientProviderName is null)
                    throw new Exception("Is not possible to configure and check the rabbit mq messenger with client provider name being null.");

                services.AddOvbRabbitMQInfrascructureConfiguration(rabbitMqHostname, rabbitMqVirtualhost, Convert.ToUInt16(rabbitMqPort), 
                    rabbitMqClientProviderName, rabbitMqUsername, rabbitMqPassword);

                services.AddTransient<IRabbitMqInsertUserConsumer, RabbitMqInsertUserConsumer>();

                services.AddTransient<IDataConnection, DataConnection>(p =>
                {
                    return new DataConnection(databaseConnectionString);
                });

                services.AddHostedService<WorkerAddUser>();
            })
            .Build();
        host.Run();
    }
}