using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Adapters;

public sealed class AdapterAccountBaseToAccountDataTransfer : IAdapter<AccountBase, AccountDataTransfer>
{
    public AccountDataTransfer Adapter(AccountBase input)
    {
        return new AccountDataTransfer(input.Name.ToString()!, input.LastName.ToString()!, input.Username.ToString()!, input.Email.ToString()!, input.Password.ToString()!,
            input.Identifier, input.TenantIdentifier, input.CorrelationIdentifier, input.SourcePlatform!, input.ExecutionUser!, (int)input.TypeAccount);
    }
}
