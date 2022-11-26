using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

public class CreateAuthenticationRequest : RequestBase
{
    public CreateAuthenticationRequest(Guid tenantIdentifier, string sourcePlatform) : base(tenantIdentifier, sourcePlatform)
    {
    }
}
