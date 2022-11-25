using OVB.Core.Domain.CrossCuting.Abstractions.DataTransferObjects;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObjects;

public class Account : DataTransferObjectBase
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    public string CPF { get; set; }

    public Account(Guid identifier, DateTime registeredOn, Guid registeredByIdentifier, DateTime lastModificationOn, Guid lastModificationByIdentifier,
        string username, string name, string surname, string password, string email, string cargo, string cpf) 
        : base(identifier, registeredOn, registeredByIdentifier, lastModificationOn, lastModificationByIdentifier)
    {
        Username = username;
        Name = name;
        Surname = surname;
        Password = password;
        Email = email;
        Cargo = cargo;
        CPF = cpf;
    }
}
