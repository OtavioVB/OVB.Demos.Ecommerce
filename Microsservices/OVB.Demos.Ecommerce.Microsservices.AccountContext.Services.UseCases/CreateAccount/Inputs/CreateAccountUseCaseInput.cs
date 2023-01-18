using ProtoBuf;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;

public sealed class CreateAccountUseCaseInput
{
    public CreateAccountUseCaseInput(string email, string username, string password, string confirmPassword)
    {
        Email = email;
        Username = username;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
