using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                //var databaseConnectionString = services.Configuration["Infrascructure:Databases:PostgreeSQL:ConnectionString"];

                services.AddTransient<IDataConnection, DataConnection>(p =>
                {
                    return new DataConnection(databaseConnectionString);
                });

                services.AddHostedService<Worker>();
            })
            .Build();
        host.Run();
    }
}