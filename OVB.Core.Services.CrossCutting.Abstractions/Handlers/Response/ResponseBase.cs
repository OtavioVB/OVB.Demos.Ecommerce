namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

public abstract class ResponseBase : IResponse
{
    public IHttpResponse HttpResponse { get; init; }

    protected ResponseBase(IHttpResponse httpResponse)
    {
        HttpResponse = httpResponse;
    }
}
