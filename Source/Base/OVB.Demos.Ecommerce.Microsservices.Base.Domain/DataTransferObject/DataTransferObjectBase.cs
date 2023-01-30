namespace OVB.Demos.Ecommerce.Microsservices.Base.Domain.DataTransferObject;

public abstract class DataTransferObjectBase
{
    protected DataTransferObjectBase(
        Guid identifier,
        Guid tenantIdentifier, 
        Guid correlationIdentifier, 
        string sourcePlatform, 
        string executionUser)
    {
        Identifier = identifier;
        TenantIdentifier = tenantIdentifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
        ExecutionUser = executionUser;
    }

    public Guid Identifier { get; set; }
    public Guid TenantIdentifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string SourcePlatform { get; set; }
    public string ExecutionUser { get; set; }
}
