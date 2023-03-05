using OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.Company.Domain.CompanyOwnerContext.DataTransferObject;

public sealed class CompanyOwner
{
    public CompanyOwner(Guid identifier, string name, string lastName, string username, string email, 
        string password, string phone, string cpf, DateTime createdOn, CompanyDataTransfer? company)
    {
        Identifier = identifier;
        Name = name;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        Phone = phone;
        Cpf = cpf;
        CreatedOn = createdOn;
        Company = company;
    }

    public Guid Identifier { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Cpf { get; set; }
    public DateTime CreatedOn { get; set; }
    public CompanyDataTransfer? Company { get; set; }
}
