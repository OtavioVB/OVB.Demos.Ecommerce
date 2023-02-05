using OpenTelemetry.Exporter;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.DependencyInjection;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}