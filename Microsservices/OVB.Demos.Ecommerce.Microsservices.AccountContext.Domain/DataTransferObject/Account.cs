using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;

public class Account
{
    public Account(Guid identifier, string username, string password, string email, TypeAccount typeAccount)
    {
        Identifier = identifier;
        Username = username;
        Password = password;
        Email = email;
        TypeAccount = typeAccount;
    }

    public Guid Identifier { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public TypeAccount TypeAccount { get; set; }
}
