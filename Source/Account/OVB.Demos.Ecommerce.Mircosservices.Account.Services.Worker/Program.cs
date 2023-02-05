using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.DependencyInjection;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Adapters;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.DependencyInjection;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<IAdapter<AccountProtobuf, AccountDataTransfer>, AdapterAccountProtobufToAccountBase>();

            services.AddOvbDomainConfiguration();

            services.AddOvbDefaultDatabaseConfiguration(hostContext.Configuration["Infrascructure:Databases:PostgreeSQL"]!);

            services.AddOvbMessengerConfiguration(
                hostName: hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:HostName"]!,
                virtualHost: hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:VirtualHost"]!,
                username: hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Username"]!,
                password: hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Password"]!,
                clientProviderName: hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:ClientProviderName"]!,
                port: Convert.ToInt32(hostContext.Configuration["Infrascructure:Messenger:RabbitMQ:Port"])!);

            services.AddHostedService<Worker>();
        })
        .Build();

        host.Run();
    }
}