using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Outputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser;

public sealed class CreateUserUseCase : IUseCase<CreateUserUseCaseInput, CreateUserUseCaseOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;

    public CreateUserUseCase(IUnitOfWork unitOfWork, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
    }

    public async Task<(bool HasDone, CreateUserUseCaseOutput Output)> ExecuteUseCaseAsync(CreateUserUseCaseInput input, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ExecuteUnitOfWorkAsync<(bool HasDone, CreateUserUseCaseOutput Output)>(async (cancellationToken) =>
        {
            var userServiceResponse = await _userService.CreateUserAsync(new CreateAccountServiceInput(input.Username, input.Name, input.LastName, input.Email,
                input.Password, input.ConfirmPassword, input.TenantIdentifier, input.CorrelationIdentifier, input.SourcePlatform), cancellationToken);

            if (userServiceResponse.HasDone == false)
            {
                return (false, (false, new CreateUserUseCaseOutput(userServiceResponse.Notifications)));
            }
            else
            {
                if (userServiceResponse.User is null)
                    throw new Exception("User Object in Create User Service can not be null.");

                return (true, (true, new CreateUserUseCaseOutput()));
            }
        }, cancellationToken);
    }
}
