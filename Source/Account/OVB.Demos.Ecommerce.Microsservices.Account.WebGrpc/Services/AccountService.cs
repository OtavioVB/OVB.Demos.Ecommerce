using Grpc.Core;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Services;

public sealed class AccountService : Account.AccountBase
{
    public override Task<CreateAccountUseCaseOutput> CreateAccount(CreateAccountUseCaseInput request, ServerCallContext context)
    {
        return base.CreateAccount(request, context);
    }

    public override Task<HealthCheckOutput> HealthCheck(HealthCheckInput request, ServerCallContext context)
    {
        return base.HealthCheck(request, context);
    }
}