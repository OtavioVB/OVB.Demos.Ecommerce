using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;

public interface IAccountService
{
    public Task<(bool HasDone, List<NotificationItem> Notifications, AccountBase? Account)> CreateAccountAsync(CreateAccountServiceInput input, CancellationToken cancellationToken);
}
