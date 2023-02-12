using Grpc.Core;
using OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Services;

public class AccountService : Account.AccountBase
{
    public override Task<CreateAccountUseCaseOutput> CreateAccount(CreateAccountUseCaseInput request, ServerCallContext context)
    {
        return base.CreateAccount(request, context);
    }
}