namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;

public struct Username
{
    private string Value { get; set; }

    public Username(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
