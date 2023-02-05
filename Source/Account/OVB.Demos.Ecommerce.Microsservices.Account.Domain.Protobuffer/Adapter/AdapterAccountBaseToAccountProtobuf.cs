using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer.Adapter;

public sealed class AdapterAccountBaseToAccountProtobuf : IAdapter<AccountBase, AccountProtobuf>
{
    public AccountProtobuf Adapter(AccountBase input)
    {
        return new AccountProtobuf()
        {
            Identifier = input.Identifier,
            CorrelationIdentifier = input.CorrelationIdentifier,
            TenantIdentifier = input.TenantIdentifier,
            ExecutionUser = input.ExecutionUser,
            SourcePlatform = input.SourcePlatform,
            Name = input.Name.ToString(),
            LastName = input.LastName.ToString(),
            Email = input.Email.ToString(),
            Username = input.Username.ToString(),
            Password = input.Password.ToString(),
            TypeAccount = (int)input.TypeAccount
        };
    }
}
