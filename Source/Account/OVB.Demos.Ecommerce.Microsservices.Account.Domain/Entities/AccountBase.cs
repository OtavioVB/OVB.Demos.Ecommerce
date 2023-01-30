using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities;

public abstract class AccountBase : DomainEntityBase
{
    public string? Name { get; private set; }
    public string? LastName { get; private set; }
    public string? Username { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }

    public virtual void CreateAccount(string name, string lastName, string username, string email, string password)
    {
        return;
    }

    private void ChangeAccountCredentials(string name, string lastName, string username, string email, string password)
    {
        Name = name;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
    }
}
