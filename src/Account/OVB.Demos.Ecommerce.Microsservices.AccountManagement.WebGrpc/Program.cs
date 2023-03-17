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

        var databaseConnectionString = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:ConnectionString"];
        var migrationsAssembly = builder.Configuration["Infrascructure:Databases:EntityFrameworkCore:PostgreeSQL:MigrationsAssembly"];

        if (databaseConnectionString is null)
            throw new Exception("Is not possible to connect in database, because the connection string is not valid.");

        if (migrationsAssembly is null)
            throw new Exception("Is not possible to configure the database, because the migrations assembly is not valid.");

        builder.Services.AddOvbInfrascructureConfiguration(databaseConnectionString, migrationsAssembly);

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