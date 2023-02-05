using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Adapters;

public sealed class AdapterCreateAccountUseCaseInputToServiceInput : IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput>
{
    public CreateAccountServiceInput Adapter(CreateAccountUseCaseInput input)
    {
        return new CreateAccountServiceInput(input.TenantIdentifier, input.CorrelationIdentifier, input.SourcePlatform, input.ExecutionSource, input.Name, input.LastName, input.Username, input.Password, input.Email);
    }
}
