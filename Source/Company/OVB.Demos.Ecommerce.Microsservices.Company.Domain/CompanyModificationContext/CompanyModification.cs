namespace OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyModificationContext;

public sealed class CompanyModification
{
    public CompanyModification(Guid identifier, Guid correlationIdentifier, string description, string modifiedBySourcePlatform,
        string executionUser, DateTime modifiedOn)
    {
        Identifier = identifier;
        CorrelationIdentifier = correlationIdentifier;
        Description = description;
        ModifiedBySourcePlatform = modifiedBySourcePlatform;
        ExecutionUser = executionUser;
        ModifiedOn = modifiedOn;
    }

    public Guid Identifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string Description { get; set; }
    public string ModifiedBySourcePlatform { get; set; }
    public string ExecutionUser { get; set; }
    public DateTime ModifiedOn { get; set; }
}
