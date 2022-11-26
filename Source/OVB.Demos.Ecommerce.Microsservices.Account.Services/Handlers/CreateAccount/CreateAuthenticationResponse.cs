using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

public class CreateAuthenticationResponse : ResponseBase
{
    public CreateAuthenticationResponse(IHttpResponse httpResponse) : base(httpResponse)
    {
    }
}
