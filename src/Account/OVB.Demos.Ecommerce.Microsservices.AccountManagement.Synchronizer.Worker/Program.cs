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

                if (databaseConnectionString is null)
                    throw new Exception("Database connection string cannot be null.");

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