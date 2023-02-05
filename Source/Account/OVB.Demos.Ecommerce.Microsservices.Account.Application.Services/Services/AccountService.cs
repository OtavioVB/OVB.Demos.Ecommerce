using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Builder.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Extensions;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services;

public sealed class AccountService : IAccountService
{
    private readonly ITraceManager _traceManager;
    private readonly IBaseRepository<AccountDataTransfer> _accountBaseRepository;
    private readonly IExtensionAccountRepository _extensionAccountRepository;
    private readonly IBuilderAccount _builderDomainAccount;
    private readonly IAdapter<AccountBase, AccountDataTransfer> _adapterDomainAccountToDataTransferAccount;

    public AccountService(
        ITraceManager traceManager,
        IBaseRepository<AccountDataTransfer> accountBaseRepository,
        IExtensionAccountRepository extensionAccountRepository,
        IBuilderAccount builderDomainAccount,
        IAdapter<AccountBase, AccountDataTransfer> adapterDomainAccountToDataTransferAccount)
    {
        _traceManager = traceManager;
        _accountBaseRepository = accountBaseRepository;
        _extensionAccountRepository = extensionAccountRepository;
        _builderDomainAccount = builderDomainAccount;
        _adapterDomainAccountToDataTransferAccount = adapterDomainAccountToDataTransferAccount;
    }

    public async Task<(bool HasDone, List<NotificationItem> Notifications, AccountBase? Account)> CreateAccountAsync(CreateAccountServiceInput input, CancellationToken cancellationToken)
    {
        var traceManagerTags = new Dictionary<string, string>();
        traceManagerTags.Add("TenantIdentifier", input.TenantIdentifier.ToString());
        traceManagerTags.Add("CorrelationIdentifier", input.CorrelationIdentifier.ToString());
        traceManagerTags.Add("SourcePlatform", input.SourcePlatform);
        return await _traceManager.StartTracing<CreateAccountServiceInput, (bool HasDone, List<NotificationItem> Notifications, AccountBase? Account)>(
            "CreateAccountServiceAsync", ActivityKind.Internal, input, async (input, activity) =>
        {
            var notifications = new List<NotificationItem>();

            var account = _builderDomainAccount.CreateAccountAccordingToYourType(TypeAccount.Default);
            var createAccountResponse = account.CreateAccount(input.TenantIdentifier, input.CorrelationIdentifier, input.SourcePlatform, input.ExecutionSource, 
                new Name(input.Name), new LastName(input.LastName), new Username(input.Username), new Email(input.Email), new Password(input.Password));

            if (createAccountResponse.HasDone == false)
            {
                notifications.AddRange(createAccountResponse.Notifications);
                return (false, notifications, null);
            }

            if (await _extensionAccountRepository.VerifyAccountExistsByUsernameOrEmail(input.TenantIdentifier, input.Email, input.Username) == true)
            {
                notifications.Add(new NotificationItem("Uma conta já existe com as credenciais inseridas.", TypeNotification.Information));
                return (false, notifications, null);
            }

            await _accountBaseRepository.AddAsync(_adapterDomainAccountToDataTransferAccount.Adapter(account));

            return (true, notifications, account);
        },  traceManagerTags);
    }
}
