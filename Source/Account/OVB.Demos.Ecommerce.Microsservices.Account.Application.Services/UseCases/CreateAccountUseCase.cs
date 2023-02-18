using Npgsql;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Publisher.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases;

public sealed class CreateAccountUseCase : IUseCase<CreateAccountUseCaseInput>
{
    private readonly ITraceManager _traceManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly IRetry _retry;
    private readonly IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> _adapterUseCaseInputToAccountServiceInput;
    private readonly IAdapter<AccountBase, AccountProtobuf> _adapterAccountBaseToAccountProtobuf;
    private readonly IMessengerSynchronizerService<AccountProtobuf> _messengerSynchronizerService;
    private readonly DataContext _dataContext;
    private readonly INotificationPublisher _notificationPublisher;

    public CreateAccountUseCase(
        ITraceManager traceManager,
        IUnitOfWork unitOfWork, 
        IAccountService accountService, 
        DataContext dataContext, 
        IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> adapterUseCaseInputToAccountServiceInput, 
        IMessengerSynchronizerService<AccountProtobuf> messengerSynchronizerService,
        IAdapter<AccountBase, AccountProtobuf> adapterAccountBaseToAccountProtobuf,
        IRetry retry,
        INotificationPublisher notificationPublisher)
    {
        _traceManager = traceManager;
        _unitOfWork = unitOfWork;
        _accountService = accountService;
        _dataContext = dataContext;
        _adapterUseCaseInputToAccountServiceInput = adapterUseCaseInputToAccountServiceInput;
        _messengerSynchronizerService = messengerSynchronizerService;
        _adapterAccountBaseToAccountProtobuf = adapterAccountBaseToAccountProtobuf;
        _retry = retry;
        _notificationPublisher = notificationPublisher;
    }

    public async Task<bool> ExecuteUseCaseAsync(CreateAccountUseCaseInput input, CancellationToken cancellationToken)
    {
        return await _traceManager.StartTracing("CreateAccountUseCaseAsync", ActivityKind.Internal, input, async (input, activity) =>
        {
            var retryResult = await _retry.TryRetry<bool, NpgsqlException>(async () =>
            {
                var transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
                return await _unitOfWork.ExecuteUnitOfWorkAsync(async (transaction, cancellationToken) =>
                {
                    var accountCreateResponse = await _accountService.CreateAccountAsync(_adapterUseCaseInputToAccountServiceInput.Adapter(input), cancellationToken);

                    if (accountCreateResponse.HasDone)
                    {
                        if (accountCreateResponse.Account is null)
                            throw new Exception("Account Service return null Account, this return is not expected.");

                        await _messengerSynchronizerService.PublishMessengerToSynchronizeDatabase(_adapterAccountBaseToAccountProtobuf.Adapter(accountCreateResponse.Account));
                        await _notificationPublisher.AddNotifications((IEnumerable<INotificationItem>)accountCreateResponse.Notifications);
                        return true;
                    }
                    else
                    {
                        await _notificationPublisher.AddNotifications((IEnumerable<INotificationItem>)accountCreateResponse.Notifications);
                        return false;
                    }
                }, transaction, cancellationToken);
            });

            if (retryResult.RetryResult == true)
                return retryResult.Output;
            else
                return false; // Implement Circuit Breaker

        }, new Dictionary<string, string>()
        .AddKeyValue("TenantIdentifier", input.TenantIdentifier.ToString())
        .AddKeyValue("CorrelationIdentifier", input.CorrelationIdentifier.ToString())
        .AddKeyValue("SourcePlatform", input.SourcePlatform));
    }
}
