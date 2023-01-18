using Microsoft.EntityFrameworkCore;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using FluentValidation.Results;
using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Mappings;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Mappings.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Notification;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Builder;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Validators.ValueObjects;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Builder;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Extension;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Adapter;
using Microsoft.OpenApi.Models;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Factory;
using RabbitMQ.Client;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Container;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Channel;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Subscriber;
using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf;
using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsageConfiguration;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsage;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs.Protobuf;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi;

public class Program
{
    public static string ServiceTitle = "Microsserviços de Contexto de Conta do Usuário.";
    public static string ServiceDescription = "Essa API é destinada as alterações no contexto de contas da aplicação do macro projeto Ecommerce.";
    public static string ServiceName = "OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi";
    public static string ServiceVersion = "0.0.1-alpha";
    public static string ServiceContact = "https://github.com/OtavioVB/OVB.Demos.Ecommerce";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // User Secrets - Database
        var npgsqlConnection = builder.Configuration["DatabaseConnections:NpgsqlStringConnection"]!;

        // User Secrets - Messenger
        var rabbitMqHostName = builder.Configuration["MessengerConnections:RabbitMQ:HostName"]!;
        var rabbitMqVirtualHost = builder.Configuration["MessengerConnections:RabbitMQ:VirtualHost"]!;
        var rabbitMqPassword = builder.Configuration["MessengerConnections:RabbitMQ:Password"]!;
        var rabbitMqUsername = builder.Configuration["MessengerConnections:RabbitMQ:UserName"]!;
        var rabbitMqPort = builder.Configuration["MessengerConnections:RabbitMQ:Port"]!;
        var rabbitMqUri = builder.Configuration["MessengerConnections:RabbitMQ:Uri"]!;

        // RabbitMQ - Messenger
        builder.Services.AddSingleton<IAsyncConnectionFactory>(p => 
        { 
            return new ConnectionFactory()
            { 
                HostName = rabbitMqHostName,
            }; 
        });
        builder.Services.AddSingleton<IFactoryMessengerConnection, FactoryMessengerConnection>();
        builder.Services.AddSingleton<IContainerMessengerConnection, ContainerMessengerConnection>();
        builder.Services.AddSingleton<IMessengerChannel, MessengerChannel>();
        builder.Services.AddSingleton<IMessengerPublisher, MessengerPublisher>();
        builder.Services.AddSingleton<IMessengerSubscriber, MessengerSubscriber>();
        builder.Services.AddSingleton<IChannelUsageConfiguration>(p =>
        {
            return new ChannelUsageConfiguration(p.GetService<IMessengerChannel>()!.GetChannel("Main")!);
        });

        // Observability
        builder.Services.AddOpenTelemetry().WithTracing(traceOpenTelemetryBuilder =>
        {
            traceOpenTelemetryBuilder
                .AddSource(ServiceName)
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(ServiceName, ServiceVersion))
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation();
        }).WithMetrics(metricsOpenTelemetryBuilder =>
        {
            metricsOpenTelemetryBuilder
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(ServiceName, ServiceVersion))
                .AddHttpClientInstrumentation();
        }).StartWithHost();

        // Serialization
        builder.Services.AddSingleton<ISerialization, Serialization>();

        // Validators
        builder.Services.AddSingleton<AbstractValidator<Email>, EmailValidator>();
        builder.Services.AddSingleton<AbstractValidator<Username>, UsernameValidator>();
        builder.Services.AddSingleton<AbstractValidator<Password>, PasswordValidator>();
        
        // Factories
        builder.Services.AddSingleton<IFactory<ValidationFailure, NotificationItem>, FactoryValidationFailureToNotification>();
        builder.Services.AddSingleton<IFactory<List<ValidationFailure>, List<NotificationItem>>, FactoryRangeValidationFailureToRangeNotification>();

        // Builder
        builder.Services.AddSingleton<IBuilder<AccountBase, TypeAccount>, AccountBuilder>();

        // Adapters
        builder.Services.AddSingleton<IAdapter<AccountBase, Account>, AdapterAccountBaseToAccount>();
        builder.Services.AddSingleton<IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput>, AdapterCreateAccountUseCaseInputToCreateAccountServiceInput>();
        builder.Services.AddSingleton<IAdapter<AccountBase, AccountProtobuf>, AdapterAccountBaseToAccountProtobuf>();

        // Mappings
        builder.Services.AddSingleton<IMapping<Account>, AccountMapping>();

        // DataContext
        builder.Services.AddDbContext<DataContext>(p => p.UseNpgsql(npgsqlConnection, p => p.MigrationsAssembly("OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi")));

        // Repositories
        builder.Services.AddScoped<IBaseRepository<Account>, AccountRepository>();
        builder.Services.AddScoped<IExtensionAccountRepository, AccountRepository>();

        // UnitOfWork
        builder.Services.AddScoped<IUnitOfWork, DefaultUnitOfWork>();

        // Services
        builder.Services.AddScoped<IAccountService, AccountService>();

        // UseCases
        builder.Services.AddScoped<IUseCase<CreateAccountUseCaseInput>, CreateAccountUseCase>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options => 
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = ServiceTitle,
                Description = ServiceDescription,
                Version = ServiceVersion,
                Contact = new OpenApiContact()
                {
                    Url = new Uri(ServiceContact),
                    Name = ServiceName
                }
            });
        });

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}