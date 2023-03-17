using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext;

public sealed class UserService : IUserService
{
    private readonly IBaseRepository<User> _userBaseRepository;
    private readonly IExtensionUserRepository _extensionUserRepository;
    private readonly IUserBuilder _userBuilder;
    private readonly IUnitOfWork _unitOfWork;

    public Task<(bool HasDone, List<string> Notifications, UserBase? User)> CreateUserAsync(CreateAccountServiceInput input, CancellationToken cancellationToken)
    {
        var notifications = new List<string>();

        throw new NotImplementedException();
    }
}
