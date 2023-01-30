namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;

public struct Name
{
    private string Value { get; set; }

    public Name(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
