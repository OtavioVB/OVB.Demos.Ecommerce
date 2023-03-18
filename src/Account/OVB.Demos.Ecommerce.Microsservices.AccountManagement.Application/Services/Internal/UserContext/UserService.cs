using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext;

public sealed class UserService : IUserService
{
    private readonly IBaseRepository<User> _userBaseRepository;
    private readonly IExtensionUserRepository _extensionUserRepository;
    private readonly IUserBuilder _userBuilder;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IBaseRepository<User> userBaseRepository,
        IExtensionUserRepository extensionUserRepository,
        IUserBuilder userBuilder,
        IUnitOfWork unitOfWork)
    {
        _userBaseRepository = userBaseRepository;
        _extensionUserRepository = extensionUserRepository;
        _userBuilder = userBuilder;
        _unitOfWork = unitOfWork;
    }

    public async Task<(bool HasDone, List<string> Notifications, UserBase? User)> CreateUserAsync(CreateAccountServiceInput input, CancellationToken cancellationToken)
    {
        var notifications = new List<string>();

        var user = _userBuilder.CreateUserDomainEntityByHisType(TypeUser.Default);
        var userDomainResponse = user.CreateBasicCredentials(input.Username, input.Email, input.LastName, input.Name, input.Password,
            input.TenantIdentifier, input.CorrelationIdentifier, input.SourcePlatform);

        if (userDomainResponse.HasDone == false)
        {
            notifications.AddRange(userDomainResponse.Notifications);
            return (false, notifications, null);
        }

        var extensionUserRepositoryWithVerificationAboutExistsEmailOrUsername = await _extensionUserRepository.VerifyUserExistsByUsernameOrEmail(
            input.Username, input.Email, cancellationToken);
        if (extensionUserRepositoryWithVerificationAboutExistsEmailOrUsername == true)
        {
            notifications.Add("As credenciais de nome de usuário ou email já estão sendo utilizadas.");
            return (false, notifications, null);
        }

        if (user.User is null)
            throw new Exception("The user data transfer object does not be null after domain entity creation execution.");

        await _userBaseRepository.AddAsync(user.User, cancellationToken);
        await _unitOfWork.AddChangesToTransaction();
        return (true, notifications, user);
    }
}
