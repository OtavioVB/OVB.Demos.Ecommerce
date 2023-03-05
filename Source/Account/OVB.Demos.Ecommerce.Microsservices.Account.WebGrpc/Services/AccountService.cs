using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Consumer.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Services;

public sealed class AccountService : Account.AccountBase
{
    private readonly IUseCase<CreateAccountUseCaseInput> _useCaseCreateAccount;
    private readonly IAdapter<CreateAccountUseCaseGrpcInput, CreateAccountUseCaseInput> _adapterInput;
    private readonly INotificationConsumer _notificationConsumer;

    public AccountService(
        [FromServices] IUseCase<CreateAccountUseCaseInput> useCaseCreateAccount, 
        [FromServices] IAdapter<CreateAccountUseCaseGrpcInput, CreateAccountUseCaseInput> adapterInput,
        [FromServices] INotificationConsumer notificationConsumer)
    {
        _notificationConsumer = notificationConsumer;
        _useCaseCreateAccount = useCaseCreateAccount;
        _adapterInput = adapterInput;
    }

    public override async Task<CreateAccountUseCaseGrpcOutput> CreateAccount(
        CreateAccountUseCaseGrpcInput request, ServerCallContext context)
    {
        var useCaseResponse = await _useCaseCreateAccount.ExecuteUseCaseAsync(_adapterInput.Adapter(request), new CancellationToken());
        var notifications = await _notificationConsumer.GetNotifications();
        var response = new CreateAccountUseCaseGrpcOutput() { Created = useCaseResponse };
        response.Messages.AddRange(notifications.Select(p => new Notification() { Message = p.Message, TypeNotification = p.TypeNotification.ToString() }));
        return response;
    }

    public override Task<HealthCheckOutput> HealthCheck(HealthCheckInput request, ServerCallContext context)
    {
        return base.HealthCheck(request, context);
    }
}