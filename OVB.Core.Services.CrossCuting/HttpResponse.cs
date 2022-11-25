using OVB.Core.Services.CrossCutting.Abstractions.Handlers.Response;
namespace OVB.Core.Services.CrossCuting;

public class HttpStatusResponse : IHttpResponse
{
    public TypeHttpResponseCode TypeHttpResponseCode { get; }
    public int Status { get; }
    public string TypeHttpResponse { get; }

    public HttpStatusResponse(TypeHttpResponseCode typeHttpResponseCode)
    {
        TypeHttpResponseCode = typeHttpResponseCode;
        Status = (int)typeHttpResponseCode;
        TypeHttpResponse = typeHttpResponseCode.ToString();
    }
}
