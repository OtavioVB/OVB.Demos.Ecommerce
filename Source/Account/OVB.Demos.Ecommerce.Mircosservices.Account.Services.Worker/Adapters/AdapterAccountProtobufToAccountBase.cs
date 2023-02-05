using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Adapters;

public sealed class AdapterAccountProtobufToAccountBase : IAdapter<AccountProtobuf, AccountDataTransfer>
{
    public AccountDataTransfer Adapter(AccountProtobuf input)
    {
        return new AccountDataTransfer(input.Name!, input.LastName!, input.Username!, input.Email!, input.Password!,
            input.Identifier, input.TenantIdentifier, input.CorrelationIdentifier, input.SourcePlatform!, input.ExecutionUser!, input.TypeAccount);
    }
}
