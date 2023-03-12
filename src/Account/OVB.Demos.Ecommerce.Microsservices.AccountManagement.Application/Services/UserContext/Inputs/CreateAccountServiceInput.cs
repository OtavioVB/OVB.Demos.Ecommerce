namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.Services.UserContext.Inputs;

public struct CreateAccountServiceInput
{
    public CreateAccountServiceInput(string username, string name, string lastName, string email, string password)
    {
        Username = username;
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string Username { get; init; }
    public string Name { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
