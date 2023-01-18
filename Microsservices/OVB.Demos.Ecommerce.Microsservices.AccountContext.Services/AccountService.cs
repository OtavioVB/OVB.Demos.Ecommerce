using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Builder;
using OVB.Demos.Ecommerce.Libraries.Notification;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Extension;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services;

public sealed class AccountService : IAccountService
{
    private readonly IBaseRepository<Account> _baseAccountRepository;
    private readonly IBuilder<AccountBase, TypeAccount> _accountBuilder;
    private readonly IAdapter<AccountBase, Account> _adapterAccountBaseToDataTransferObject;
    private readonly IExtensionAccountRepository _extensionAccountRepository;

    public AccountService(
        IBaseRepository<Account> baseAccountRepository, 
        IBuilder<AccountBase, TypeAccount> accountBuilder, 
        IAdapter<AccountBase, Account> adapterAccountBaseToDataTransferObject, 
        IExtensionAccountRepository extensionAccountRepository)
    {
        _baseAccountRepository = baseAccountRepository;
        _accountBuilder = accountBuilder;
        _adapterAccountBaseToDataTransferObject = adapterAccountBaseToDataTransferObject;
        _extensionAccountRepository = extensionAccountRepository;
    }

    public async Task<(bool HasExecuted, List<NotificationItem> Notifications, AccountBase? Account)> CreateAccountAsync(CreateAccountServiceInput input, IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var notifications = new List<NotificationItem>();
        var account = _accountBuilder.BuildEntityByType(TypeAccount.Default);

        if (cancellationToken.IsCancellationRequested == true)
        {
            notifications.Add(new NotificationItem("A operação de criação da conta de usuário foi cancelada.", TypeNotification.Warning));
            return (false, notifications, null);
        }

        if (input.Password != input.ConfirmPassword)
        {
            notifications.Add(new NotificationItem(AccountBase.Messages.PasswordConfirmIsNotValidMessage, TypeNotification.Information));
            return (false, notifications, null);
        }

        var accountCreationResponse = account.CreateAccount(
            new Username(input.Username),
            new Password(input.Password),
            new Email(input.Email));

        if (accountCreationResponse.HasDone == false)
        {
            notifications.AddRange(accountCreationResponse.Notifications);
            return (false, notifications, null);
        }

        if (await _extensionAccountRepository.VerifyAccountExistsByUsernameOrEmail(input.Username, input.Email) is true)
        {
            notifications.Add(new NotificationItem(AccountBase.Messages.AccountExistsInDatabaseMessage, TypeNotification.Information));
            return (false, notifications, null);
        }

        var accountDataTransferObject = _adapterAccountBaseToDataTransferObject.Adapt(account);
        await _baseAccountRepository.AddAsync(accountDataTransferObject);

        return (true, notifications, account);
    }
}
