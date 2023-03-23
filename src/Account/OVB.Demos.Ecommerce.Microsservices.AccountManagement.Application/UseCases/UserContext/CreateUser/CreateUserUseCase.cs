using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.External.MessengerContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.Internal.UserContext.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Outputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser;

public sealed class CreateUserUseCase : IUseCase<CreateUserUseCaseInput, CreateUserUseCaseOutput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly ICircuitBreakerFunctions _circuitBreaker;
    private readonly IMessengerSynchronizerService _messengerSynchronizerService;

    public CreateUserUseCase(
        IUnitOfWork unitOfWork, 
        IUserService userService, 
        ICircuitBreakerFunctions circuitBreaker,
        IMessengerSynchronizerService messengerSynchronizerService)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
        _circuitBreaker = circuitBreaker;
        _messengerSynchronizerService = messengerSynchronizerService;
    }

    public async Task<(bool HasDone, CreateUserUseCaseOutput Output)> ExecuteUseCaseAsync(CreateUserUseCaseInput input, CancellationToken cancellationToken)
    {
        var result = await _circuitBreaker.ExecuteCircuitBreakerAsync("Npgsql", async (cancellationToken) =>
        {
            var result = await _circuitBreaker.ExecuteCircuitBreakerAsync("Postgres", async (cancellationToken) =>
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

                        await _messengerSynchronizerService.PublishMessageToBusToSynchronizeDatabaseWithInsert(
                            new UserProtobuffer(userServiceResponse.User.Username.ToString(), userServiceResponse.User.Name.ToString(), 
                            userServiceResponse.User.LastName.ToString(), userServiceResponse.User.Email.ToString(), 
                            userServiceResponse.User.Password.ToString(), 1, userServiceResponse.User.IsEmailConfirmed, userServiceResponse.User.Identifier.ToString(),
                            userServiceResponse.User.CorrelationIdentifier.ToString(), userServiceResponse.User.TenantIdentifier.ToString(), 
                            userServiceResponse.User.SourcePlatform.ToString(), userServiceResponse.User.CreatedOn), 
                            input.CorrelationIdentifier, input.TenantIdentifier, input.SourcePlatform);

                        return (true, (true, new CreateUserUseCaseOutput()));
                    }
                }, cancellationToken);
            }, cancellationToken);

            if (result.HasDone is true)
                return result.Output;
            else
                throw new NotImplementedException();
        }, cancellationToken);

        if (result.HasDone is true)
            return result.Output;
        else
            throw new NotImplementedException();
    }
}
