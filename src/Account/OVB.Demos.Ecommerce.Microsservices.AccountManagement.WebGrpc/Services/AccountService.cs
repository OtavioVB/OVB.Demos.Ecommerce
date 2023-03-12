using Grpc.Core;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;

public class AccountService : Account.AccountBase
{
    public override Task<CreateAccountOutput> CreateUserAccount(CreateAccountInput request, ServerCallContext context)
    {
        return Task.FromResult(new CreateAccountOutput(){
            StatusCode = 200
        });
    }
}