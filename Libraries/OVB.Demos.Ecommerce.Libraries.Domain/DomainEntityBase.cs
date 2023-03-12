using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain;

public abstract class DomainEntityBase
{
    public Guid Identifier { get; protected set; }
    public Guid TenantIdentifier { get; protected set; }
    public Guid CorrelationIdentifier { get; protected set; }
    public SourcePlatform SourcePlatform { get; protected set; }
    public DateTime CreatedOn { get; protected set; }
}
