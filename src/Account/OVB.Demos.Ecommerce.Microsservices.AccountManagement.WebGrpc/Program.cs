using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
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

        builder.Services.AddGrpc();
        var app = builder.Build();
        app.MapGrpcService<AccountService>();
        app.MapGet("/", () => "Communication with gRPC endpoints.");
        app.Run();
    }
}