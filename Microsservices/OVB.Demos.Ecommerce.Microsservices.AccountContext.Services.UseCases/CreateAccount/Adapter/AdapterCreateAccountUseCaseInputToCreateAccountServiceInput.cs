using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Adapter;

public class AdapterCreateAccountUseCaseInputToCreateAccountServiceInput : IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput>
{
    public CreateAccountServiceInput Adapt(CreateAccountUseCaseInput adaptee)
    {
        return new CreateAccountServiceInput(adaptee.Username, adaptee.Email, adaptee.Password, adaptee.ConfirmPassword);
    }
}
