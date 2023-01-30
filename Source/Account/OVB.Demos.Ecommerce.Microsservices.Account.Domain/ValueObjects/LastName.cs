namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;


public struct LastName
{
    private string Value { get; set; }

    public LastName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
