using OVB.Core.Services.CrossCutting.Abstractions.Handlers;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

public abstract class CreateAuthenticationHandlerBase : HandleBase<CreateAuthenticationResponse, CreateAuthenticationRequest>
{
    protected override Task<CreateAuthenticationResponse> HandleWorkflowAsync(CreateAuthenticationRequest request)
    {
        throw new NotImplementedException();
    }
}
