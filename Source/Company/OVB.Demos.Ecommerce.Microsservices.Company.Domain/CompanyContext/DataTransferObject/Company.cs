using OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyModificationContext;

namespace OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyContext.DataTransferObject;

public sealed class Company
{
    public Guid TenantIdentifier { get; set; }
    public string Cnpj { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime IsAvailableUntil { get; set; }

    public DateTime CreatedOn { get; set; }
    public string CreatedBySourcePlatform { get; set; }
    public Guid CreatedByCorrelationIdentifier { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public List<CompanyModification> CompanyModifications { get; set; }
}
