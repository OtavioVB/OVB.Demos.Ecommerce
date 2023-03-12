using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext;

public sealed class UserService : IUserService
{
    private readonly IBaseRepository<User> _userBaseRepository;

    public Task<(bool HasDone, List<string> Notifications, UserBase? User)> CreateUserAsync(CreateAccountServiceInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
