using Grpc.Core;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.Services;

public class GreeterService : Account.AccountBase
{
    public override Task<CreateAccountOutput> CreateAccount(CreateAccountInput request, ServerCallContext context)
    {
        return base.CreateAccount(request, context);
    }
}