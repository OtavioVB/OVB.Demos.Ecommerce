using OVB.Demos.Ecommerce.Libraries.Domain;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountAddressContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountPhoneContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;

public sealed class Account : DataTransferObjectBase
{
    public Account(string cpf, string generalRegistry, Guid identifier, Guid tenantIdentifier, Guid correlationIdentifier, 
        string sourcePlatform, DateTime createdOn, string addressComplement) : base(identifier, tenantIdentifier, correlationIdentifier, sourcePlatform, createdOn)
    {
        Cpf = cpf;
        GeneralRegistry = generalRegistry;
        AddressComplement = addressComplement;
    }

    public string Cpf { get; set; }
    public string GeneralRegistry { get; set; }
    public string AddressComplement { get; set; }
    public AccountAddress? AccountAddress { get; set; }
    public List<AccountPhone> AccountPhones { get; set; } = new List<AccountPhone>(); 
    public User? User { get; set; }
}
