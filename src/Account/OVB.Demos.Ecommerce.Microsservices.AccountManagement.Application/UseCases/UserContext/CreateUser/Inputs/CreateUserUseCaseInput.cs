namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.UserContext.CreateUser.Inputs;

public struct CreateUserUseCaseInput
{
    public CreateUserUseCaseInput(string username, string name, string lastName, string email, string password, string confirmPassword, Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform)
    {
        Username = username;
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        TenantIdentifier = tenantIdentifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
    }

    public string Username { get; init; }
    public string Name { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
    public Guid TenantIdentifier { get; init; }
    public Guid CorrelationIdentifier { get; init; }
    public string SourcePlatform { get; init; }
}
