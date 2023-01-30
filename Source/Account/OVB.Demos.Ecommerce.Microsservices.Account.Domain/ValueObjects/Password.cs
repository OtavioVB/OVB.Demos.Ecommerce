namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;

public struct Password
{
    private string Value { get; set; }

    public Password(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
