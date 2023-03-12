using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Interfaces;

public interface IUserService
{
    public Task<(bool HasDone, List<string> Notifications, UserBase? User)> CreateUserAsync(CreateAccountServiceInput input, CancellationToken cancellationToken);
}
