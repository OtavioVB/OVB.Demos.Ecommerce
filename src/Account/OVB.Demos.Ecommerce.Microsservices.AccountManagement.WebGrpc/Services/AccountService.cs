using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Outputs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;

public class AccountService : Account.AccountBase
{
    private readonly IUseCase<CreateUserUseCaseInput, CreateUserUseCaseOutput> _useCaseCreateUser;

    public AccountService([FromServices] IUseCase<CreateUserUseCaseInput, CreateUserUseCaseOutput> useCaseCreateUser)
    {
        _useCaseCreateUser = useCaseCreateUser;
    }

    public override async Task<CreateAccountOutput> CreateUserAccount(CreateAccountInput request, ServerCallContext context)
    {
        try
        {
            var useCaseResponse = await _useCaseCreateUser.ExecuteUseCaseAsync(new CreateUserUseCaseInput(
                request.Username, request.Name, request.LastName, request.Email, request.Password, request.ConfirmPassword,
                new Guid(request.TenantIdentifier), new Guid(request.CorrelationIdentifier), request.SourcePlatform), context.CancellationToken);

            if (useCaseResponse.HasDone == true)
            {
                return (new CreateAccountOutput()
                {
                    StatusCode = 200
                });
            }
            else
            {
                var outputResponse = new CreateAccountOutput() { StatusCode = 422 };
                outputResponse.Messages.AddRange(useCaseResponse.Output.Notifications);
                return (outputResponse);
            }
        }
        catch
        {
            return (new CreateAccountOutput()
            {
                StatusCode = 500
            });
        }
    }
}