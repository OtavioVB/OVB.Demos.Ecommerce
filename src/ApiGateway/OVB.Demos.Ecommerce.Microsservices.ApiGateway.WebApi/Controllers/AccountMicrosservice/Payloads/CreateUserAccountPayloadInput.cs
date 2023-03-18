namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi.Controllers.AccountMicrosservice.Payloads;

public sealed class CreateUserAccountPayloadInput
{
    public CreateUserAccountPayloadInput(string username, string name, string lastName, string email, 
        string password, string confirmPassword, Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform)
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

    public string Username { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public Guid TenantIdentifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string SourcePlatform { get; set; }
}
