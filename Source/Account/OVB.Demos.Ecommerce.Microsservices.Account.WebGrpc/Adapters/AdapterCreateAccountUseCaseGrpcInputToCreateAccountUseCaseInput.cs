using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.Adapters;

public class AdapterCreateAccountUseCaseGrpcInputToCreateAccountUseCaseInput : IAdapter<CreateAccountUseCaseGrpcInput, CreateAccountUseCaseInput>
{
    public CreateAccountUseCaseInput Adapter(CreateAccountUseCaseGrpcInput input)
    {
        return new CreateAccountUseCaseInput(
            new Guid(input.TenantIdentifier), 
            new Guid(input.CorrelationIdentifier),
            input.SourcePlatform,
            input.ExecutionSource, 
            input.Name, 
            input.LastName, 
            input.Username, 
            input.Password, 
            input.Email);
    }
}
