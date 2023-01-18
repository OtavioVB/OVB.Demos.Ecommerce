using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Libraries.Notification;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;

public interface IAccountService
{
    public Task<(bool HasExecuted, List<NotificationItem> Notifications, AccountBase? Account)> CreateAccountAsync(CreateAccountServiceInput input, IDbContextTransaction transaction, CancellationToken cancellationToken);
}
