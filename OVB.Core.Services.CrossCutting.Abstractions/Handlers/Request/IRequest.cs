namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;

public interface IRequest
{
    public Guid TenantIdentifier { get; init; }
    public string SourcePlatform { get; init; }
}
