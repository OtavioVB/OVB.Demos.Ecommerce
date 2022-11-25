using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;

namespace OVB.Deoms.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

public class CreateAccountRequest : RequestBase
{
    public CreateAccountRequest(Guid tenantIdentifier, string sourcePlatform) : base(tenantIdentifier, sourcePlatform)
    {
    }
}
