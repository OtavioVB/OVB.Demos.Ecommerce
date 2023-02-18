using Grpc.Core;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Services;

public sealed class AccountService : Account.AccountBase
{
    private readonly IUseCase<CreateAccountUseCaseInput> _useCaseCreateAccount;
    private readonly IAdapter<CreateAccountUseCaseGrpcInput, CreateAccountUseCaseInput> _adapterInput;
    private readonly CancellationToken _cancellationToken;

    public AccountService(
        IUseCase<CreateAccountUseCaseInput> useCaseCreateAccount, 
        IAdapter<CreateAccountUseCaseGrpcInput, CreateAccountUseCaseInput> adapterInput, 
        CancellationToken cancellationToken)
    {
        _useCaseCreateAccount = useCaseCreateAccount;
        _adapterInput = adapterInput;
        _cancellationToken = cancellationToken;
    }

    public override async Task<CreateAccountUseCaseGrpcOutput> CreateAccount(
        CreateAccountUseCaseGrpcInput request, ServerCallContext context)
    {
        var useCaseResponse = await _useCaseCreateAccount.ExecuteUseCaseAsync(_adapterInput.Adapter(request), _cancellationToken);
        return new CreateAccountUseCaseGrpcOutput()
        {
            Created = true
        };
    }

    public override Task<HealthCheckOutput> HealthCheck(HealthCheckInput request, ServerCallContext context)
    {
        return base.HealthCheck(request, context);
    }
}