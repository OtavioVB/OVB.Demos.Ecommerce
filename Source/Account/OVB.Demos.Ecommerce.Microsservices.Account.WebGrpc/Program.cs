using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Exporter;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Adapters;
using OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Services;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
using System.Net;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(p =>
            {
                p.Listen(IPAddress.Any, 5001, p =>
                {
                    p.Protocols = HttpProtocols.Http2;
                    p.UseHttps();
                });
            });

            builder.Services.AddSingleton<IAdapter<CreateAccountUseCaseGrpcInput, CreateAccountUseCaseInput>, AdapterCreateAccountUseCaseGrpcInputToCreateAccountUseCaseInput>();

            #region Domain Notification Configuration

            builder.Services.AddOvbNotificationConfigurationDependencies();

            #endregion

            #region Domain Configuration

            builder.Services.AddOvbDomainConfiguration();

            #endregion

            #region Observability Configuration

            builder.Services.AddOvbTracingAndMetrics(
                builder.Configuration["ApplicationInformation:ServiceName"]!,
                builder.Configuration["ApplicationInformation:ServiceVersion"]!,
                new Uri(builder.Configuration["Observability:OpenTelemetry:GrpcPort"]!),
                OtlpExportProtocol.Grpc);

            #endregion

            #region Policy Resilience Configuration

            builder.Services.AddScoped<IRetry, Retry>();

            #endregion

            #region Infrascructure Configuration

            builder.Services.AddOvbInfrascructureConfiguration(
                builder.Configuration["Infrascructure:Databases:PostgreeSQL"]!,
                "OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data");

            #endregion

            #region Messenger Configuration

            builder.Services.AddOvbMessengerConfiguration(
                hostName: builder.Configuration["Infrascructure:Messenger:RabbitMQ:HostName"]!,
                virtualHost: builder.Configuration["Infrascructure:Messenger:RabbitMQ:VirtualHost"]!,
                username: builder.Configuration["Infrascructure:Messenger:RabbitMQ:Username"]!,
                password: builder.Configuration["Infrascructure:Messenger:RabbitMQ:Password"]!,
                clientProviderName: builder.Configuration["Infrascructure:Messenger:RabbitMQ:ClientProviderName"]!,
                port: Convert.ToInt32(builder.Configuration["Infrascructure:Messenger:RabbitMQ:Port"]!));

            #endregion

            #region Application Services Configuration

            builder.Services.AddOvbApplicationServicesConfiguration();

            #endregion

            builder.Services.AddGrpc(p => p.EnableDetailedErrors = true);
            var app = builder.Build();
            app.Services.GetService<DataContext>()!.Database.Migrate();
            app.MapGrpcService<AccountService>();
            app.MapPost("/v1/account/create", async context => 
            {
                await context.Response.WriteAsync("");
            });
            app.Run();
        }
    }
}