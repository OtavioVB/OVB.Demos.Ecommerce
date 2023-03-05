using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyContext.Entities;

public abstract class CompanyBase : DomainEntityBase
{
    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Description { get; private set; }
}
