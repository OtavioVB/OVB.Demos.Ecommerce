using OVB.Core.Domain.CrossCutting.Abstractions.DataTransferObjects;

namespace OVB.Core.Domain.CrossCuting.Abstractions.DataTransferObjects;

public abstract class DataTransferObjectBase : IDataTransferObject
{
    public Guid Identifier { get;set; }
    public DateTime RegisteredOn { get; set; }
    public Guid RegisteredByIdentifier { get; set; }
    public DateTime LastModificationOn { get; set; }
    public Guid LastModificationByIdentifier { get; set; }

    protected DataTransferObjectBase(Guid identifier, DateTime registeredOn, Guid registeredByIdentifier, DateTime lastModificationOn, Guid lastModificationByIdentifier)
    {
        Identifier = identifier;
        RegisteredOn = registeredOn;
        RegisteredByIdentifier = registeredByIdentifier;
        LastModificationOn = lastModificationOn;
        LastModificationByIdentifier = lastModificationByIdentifier;
    }
}
