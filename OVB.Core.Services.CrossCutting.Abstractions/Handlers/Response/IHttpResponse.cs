namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

public interface IHttpResponse
{
    public TypeHttpResponseCode TypeHttpResponseCode { get; init; }
    public int Status { get; init; }
    public string TypeHttpResponse { get; init; }
}
