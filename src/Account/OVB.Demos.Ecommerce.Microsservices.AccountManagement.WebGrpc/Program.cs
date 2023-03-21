using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;
using System.Security.Authentication;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Kestrel Configuration

        builder.WebHost.ConfigureKestrel(p =>
        {
            p.ListenLocalhost(5200, p =>
            {
                p.Protocols = HttpProtocols.Http2;
            });
        });

        #endregion

        #region Domain Configuration

        builder.Services.AddOvbDomainAccountManagementMicrosserviceConfiguration();

        #endregion

        #region Infrascructure Configuration

        // PostgreeSQL 
        var databaseConnectionString = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:ConnectionString"];
        var migrationsAssembly = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:MigrationsAssembly"];

        // PostgreeSQL Health Checks
        var serviceName = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:ServiceName"];
        var serviceVersion = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:ServiceVersion"];
        var serviceDescription = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:ServiceDescription"];

        // RabbitMq
        var rabbitMqVirtualhost = builder.Configuration["Infrascructure:Messenger:RabbitMQ:Virtualhost"];
        var rabbitMqHostname = builder.Configuration["Infrascructure:Messenger:RabbitMQ:Hostname"];
        var rabbitMqUsername = builder.Configuration["Infrascructure:Messenger:RabbitMQ:Username"];
        var rabbitMqPort = builder.Configuration["Infrascructure:Messenger:RabbitMQ:Port"];
        var rabbitMqPassword = builder.Configuration["Infrascructure:Messenger:RabbitMQ:Password"];
        var rabbitMqClientProviderName = builder.Configuration["Infrascructure:Messenger:RabbitMQ:ClientProviderName"];

        if (databaseConnectionString is null)
            throw new Exception("Is not possible to connect in database, because the connection string is not valid.");

        if (migrationsAssembly is null)
            throw new Exception("Is not possible to configure the database, because the migrations assembly is not valid.");

        if (serviceName is null)
            throw new Exception("Is not possible to configure and check the database with service name being null.");

        if (serviceVersion is null)
            throw new Exception("Is not possible to configure and check the database with service version being null.");

        if (serviceDescription is null)
            throw new Exception("Is not possible to configure and check the database with service description being null.");

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

        bool isValidPort = Int32.TryParse(rabbitMqPort, out int rabbitMqValidPort);

        if (isValidPort == false)
            throw new Exception("Is not possible to configure and check the rabbit mq messenger with port being in a not valid state.");

        builder.Services.AddOvbInfrascructureConfiguration(databaseConnectionString, migrationsAssembly, serviceName, serviceVersion, serviceDescription, rabbitMqHostname,
            rabbitMqVirtualhost, rabbitMqValidPort, rabbitMqClientProviderName, rabbitMqUsername, rabbitMqPassword);

        #endregion

        #region Application Configuration

        builder.Services.AddOvbAccountManagementMicrosserviceApplicationConfiguration();

        #endregion

        builder.Services.AddGrpc();
        var app = builder.Build();
        app.MapGrpcService<AccountService>();
        app.MapGet("/", () => "Communication with endpoints.");
        app.Run();
    }
}