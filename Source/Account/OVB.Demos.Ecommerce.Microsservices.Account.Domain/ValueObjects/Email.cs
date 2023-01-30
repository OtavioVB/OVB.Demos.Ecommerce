namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;

public struct Email
{
    private string Value { get; set; }

    public Email(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
