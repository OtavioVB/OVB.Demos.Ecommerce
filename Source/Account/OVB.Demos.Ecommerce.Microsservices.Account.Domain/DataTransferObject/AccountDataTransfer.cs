using OVB.Demos.Ecommerce.Microsservices.Base.Domain.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;

public sealed class AccountDataTransfer : DataTransferObjectBase
{
    public AccountDataTransfer(string name, string lastName, string username, string email, string password, 
        Guid identifier, Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform, string executionUser, int typeAccount) 
        : base(identifier, tenantIdentifier, correlationIdentifier, sourcePlatform, executionUser)
    {
        Name = name;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        TypeAccount = typeAccount;
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int TypeAccount { get; set; }
}
