using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Interfaces;

public interface IUserService
{
    public Task<(bool HasDone, List<string> Notifications, UserBase? User)> CreateUserAsync(CreateAccountServiceInput input, CancellationToken cancellationToken);
}
