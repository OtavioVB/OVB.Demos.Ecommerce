using OVB.Core.Services.CrossCutting.Abstractions.Handlers;

namespace OVB.Deoms.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

public class CreateAccountHandler : HandleBase<CreateAccountResponse, CreateAccountRequest>
{
    protected override Task<CreateAccountResponse> HandleWorkflowAsync(CreateAccountRequest request)
    {
        throw new NotImplementedException();
    }
}
