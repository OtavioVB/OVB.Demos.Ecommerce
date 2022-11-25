namespace OVB.Core.Domain.CrossCutting.Abstractions.DataTransferObjects;

public interface IDataTransferObject
{
    public Guid Identifier { get; set; }

    public DateTime RegisteredOn { get; set; }
    public Guid RegisteredByIdentifier { get; set; }

    public DateTime LastModificationOn { get; set; }
    public Guid LastModificationByIdentifier { get; set; }
}
