namespace OVB.Core.Domain.CrossCutting.Abstractions.Entities;

public abstract class EntityBase
{
    public Guid Identifier { get; init; }

    public DateTime RegisteredOn { get; init; }
    public Guid RegisteredByIdentifier { get; init; }

    public DateTime LastModificationOn { get; private set; }
    public Guid LastModificationByIdentifier { get; private set; }

    protected EntityBase(Guid identifier, DateTime registeredOn, Guid registeredByIdentifier, DateTime lastModificationOn, Guid lastModificationByIdentifier)
    {
        Identifier = identifier;
        RegisteredOn = registeredOn;
        RegisteredByIdentifier = registeredByIdentifier;
        LastModificationOn = lastModificationOn;
        LastModificationByIdentifier = lastModificationByIdentifier;
    }

    protected virtual void ChangeLastModification(DateTime lastModificationOn)
    {
        LastModificationOn = LastModificationOn;
    }

    protected virtual void ChangeLastModificationByIdentifier(Guid lastModificationByIdentifier)
    {
        LastModificationByIdentifier = lastModificationByIdentifier;
    }
}
