namespace OVB.Demos.Ecommerce.Microsservices.ApiGateway.Controllers.Paylods;

public class CreateAccountPayloadInput
{
    public CreateAccountPayloadInput(Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform, string executionSource, 
        string name, string lastName, string username, string password, string email)
    {
        TenantIdentifier = tenantIdentifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
        ExecutionSource = executionSource;
        Name = name;
        LastName = lastName;
        Username = username;
        Password = password;
        Email = email;
    }

    public Guid TenantIdentifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string SourcePlatform { get; set; }
    public string ExecutionSource { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
