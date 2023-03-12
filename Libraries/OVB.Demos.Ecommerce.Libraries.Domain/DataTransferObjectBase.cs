namespace OVB.Demos.Ecommerce.Libraries.Domain;

public abstract class DataTransferObjectBase
{
    protected DataTransferObjectBase(Guid identifier, Guid tenantIdentifier, Guid correlationIdentifier, 
        string sourcePlatform, DateTime createdOn)
    {
        Identifier = identifier;
        TenantIdentifier = tenantIdentifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
        CreatedOn = createdOn;
    }

    public Guid Identifier { get; set; }
    public Guid TenantIdentifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string SourcePlatform { get; set; }
    public DateTime CreatedOn { get; set; }
}
