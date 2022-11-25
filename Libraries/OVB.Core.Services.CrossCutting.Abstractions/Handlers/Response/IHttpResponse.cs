namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;

public interface IHttpResponse
{
    public TypeHttpResponseCode TypeHttpResponseCode { get; }
    public int Status { get; }
    public string TypeHttpResponse { get; }
}
