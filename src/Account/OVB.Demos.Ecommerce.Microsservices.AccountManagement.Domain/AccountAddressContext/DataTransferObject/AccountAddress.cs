using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountAddressContext.DataTransferObject;

public sealed class AccountAddress
{
    public AccountAddress(
        Guid identifier,
        string streetName,
        string neighborhood,
        string city,
        string state,
        string country,
        string postalCode)
    {
        Identifier = identifier;
        StreetName = streetName;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
    }

    public Guid Identifier { get; set; }
    public string StreetName { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public List<Account> Accounts { get; set; } = new List<Account>();
}
