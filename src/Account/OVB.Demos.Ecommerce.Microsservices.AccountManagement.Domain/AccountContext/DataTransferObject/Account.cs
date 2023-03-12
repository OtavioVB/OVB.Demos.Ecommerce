using OVB.Demos.Ecommerce.Libraries.Domain;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;

public sealed class Account : DataTransferObjectBase
{
    public Account(string cpf, string generalRegistry, string phone, Guid identifier, Guid tenantIdentifier, Guid correlationIdentifier, 
        string sourcePlatform, DateTime createdOn) : base(identifier, tenantIdentifier, correlationIdentifier, sourcePlatform, createdOn)
    {
        Cpf = cpf;
        GeneralRegistry = generalRegistry;
        Phone = phone;
    }

    public string Cpf { get; set; }
    public string GeneralRegistry { get; set; }
    public string Phone { get; set; }
    public User? User { get; set; }
}
