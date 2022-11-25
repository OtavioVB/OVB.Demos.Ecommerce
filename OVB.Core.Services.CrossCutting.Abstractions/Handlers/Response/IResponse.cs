namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

public interface IResponse
{
    public IHttpResponse HttpResponse { get; init; }
}
