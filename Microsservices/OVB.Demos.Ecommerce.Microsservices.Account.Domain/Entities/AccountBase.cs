using OVB.Core.Domain.CrossCutting.Abstractions.Entities;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities;

public class AccountBase : EntityBase
{
    public string Username { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string Cargo { get; private set; }
    public string CPF { get; private set; }
    public TypeAccount TypeAccount { get; init; }

    protected AccountBase(Guid identifier, DateTime registeredOn, Guid registeredByIdentifier, DateTime lastModificationOn, Guid lastModificationByIdentifier,
        string username, string name, string surname, string password, string email, string cargo, string cpf, TypeAccount typeAccount) 
        : base(identifier, registeredOn, registeredByIdentifier, lastModificationOn, lastModificationByIdentifier)
    {
        Username = username;
        Name = name;
        Surname = surname;
        Password = password;
        Email = email;
        Cargo = cargo;
        CPF = cpf;
        TypeAccount = typeAccount;
    }

    public virtual void ChangeUsername(string username)
    {
        Username = username;
    }

    public virtual void ChangeName(string name)
    {
        Name = name;
    }

    public virtual void ChangeSurname(string password)
    {
        Password = password;
    }

    public virtual void ChangeEmail(string email)
    {
        Email = email;
    }

    public virtual void ChangeCargo(string cargo)
    {
        Cargo = cargo;
    }

    public virtual void ChangeCPF(string cpf)
    {
        CPF = cpf;
    }
}
