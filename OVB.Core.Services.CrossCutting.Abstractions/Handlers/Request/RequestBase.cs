namespace OVB.Core.Services.CrossCutting.Abstractions.Handlers.Request;

public abstract class RequestBase : IRequest
{
    public Guid TenantIdentifier { get; init; }
    public string SourcePlatform { get; init; }

    protected RequestBase(Guid tenantIdentifier, string sourcePlatform)
    {
        TenantIdentifier = tenantIdentifier;
        SourcePlatform = sourcePlatform;
    }
}
