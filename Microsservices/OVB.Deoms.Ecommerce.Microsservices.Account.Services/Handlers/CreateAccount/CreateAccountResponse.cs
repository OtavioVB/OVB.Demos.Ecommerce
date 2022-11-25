using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

namespace OVB.Deoms.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount;

public class CreateAccountResponse : ResponseBase
{
    public CreateAccountResponse(IHttpResponse httpResponse) : base(httpResponse)
    {
    }
}
