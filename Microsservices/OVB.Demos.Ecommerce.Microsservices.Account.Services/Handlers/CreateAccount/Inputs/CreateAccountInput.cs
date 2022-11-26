using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Common.Models.Properties;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Services.Handlers.CreateAccount.Inputs;

public class CreateAccountInput : IAccountProperties
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Office { get; set; }
    public string CPF { get; set; }

    public CreateAccountInput(string username, string name, string surname, string password, string email, string office, string cpf)
    {
        Username = username;
        Name = name;
        Surname = surname;
        Password = password;
        Email = email;
        Office = office;
        CPF = cpf;
    }
}
