using OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyModificationContext;
using OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyOwnerContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyContext.DataTransferObject;

public sealed class CompanyDataTransfer
{
    public CompanyDataTransfer(Guid tenantIdentifier, string cnpj, string name, string description, DateTime isAvailableUntil, 
        DateTime createdOn, string createdBySourcePlatform, Guid createdByCorrelationIdentifier, DateTime lastModifiedOn)
    {
        TenantIdentifier = tenantIdentifier;
        Cnpj = cnpj;
        Name = name;
        Description = description;
        IsAvailableUntil = isAvailableUntil;
        CreatedOn = createdOn;
        CreatedBySourcePlatform = createdBySourcePlatform;
        CreatedByCorrelationIdentifier = createdByCorrelationIdentifier;
        LastModifiedOn = lastModifiedOn;
    }

    public Guid TenantIdentifier { get; set; }
    public string Cnpj { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime IsAvailableUntil { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBySourcePlatform { get; set; }
    public Guid CreatedByCorrelationIdentifier { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public List<CompanyModification> CompanyModifications { get; set; } = new List<CompanyModification>();
    public List<CompanyOwner> Owners { get; set; } = new List<CompanyOwner>();
}
