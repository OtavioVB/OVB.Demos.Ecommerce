using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Adapters;

public class AdapterAccountBaseToAccount : IAdapter<AccountBase, Account>
{
    public Account Adapt(AccountBase adaptee)
    {
        return new Account(adaptee.Identifier, adaptee.Username.ToString(), adaptee.Password.ToString(), adaptee.Email.ToString(), adaptee.TypeAccount);
    }
}
