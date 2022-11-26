namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Common.Models.Properties;

public interface IAccountGettersProperties
{
    public string Username { get; }
    public string Name { get; }
    public string Surname { get; }
    public string Password { get; }
    public string Email { get; }
    public string Cargo { get; }
    public string CPF { get; }
}
