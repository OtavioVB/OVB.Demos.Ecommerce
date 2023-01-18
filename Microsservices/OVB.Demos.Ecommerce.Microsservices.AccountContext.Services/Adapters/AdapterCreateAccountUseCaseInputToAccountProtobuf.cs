using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs.Protobuf;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Adapters;

public class AdapterAccountBaseToAccountProtobuf : IAdapter<AccountBase, AccountProtobuf>
{
    public AccountProtobuf Adapt(AccountBase adaptee)
    {
        return new AccountProtobuf()
        {
            Identifier = adaptee.Identifier.ToString(),
            Username = adaptee.Username.ToString(),
            Password = adaptee.Password.ToString(),
            Email = adaptee.Email.ToString(),
            TypeAccount = (int)adaptee.TypeAccount
        };
    }
}
