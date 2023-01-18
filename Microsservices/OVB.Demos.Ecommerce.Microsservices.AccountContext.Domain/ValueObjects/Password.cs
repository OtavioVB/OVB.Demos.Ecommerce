namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

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
