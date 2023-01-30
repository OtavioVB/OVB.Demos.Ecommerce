namespace OVB.Demos.Ecommerce.Microsservices.Base.Domain.Entities;

public abstract class DomainEntityBase
{
    public Guid Identifier { get; protected set; }
    public Guid TenantIdentifier { get; protected set; }
    public Guid CorrelationIdentifier { get; protected set; }
    public string? SourcePlatform { get; protected set; }
    public string? ExecutionUser { get; protected set; }

    protected void ChangeTracingOfEntity(Guid identifier, Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform, string executionUser)
    {
        Identifier = identifier;
        TenantIdentifier = tenantIdentifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
        ExecutionUser = executionUser;
    }
}
