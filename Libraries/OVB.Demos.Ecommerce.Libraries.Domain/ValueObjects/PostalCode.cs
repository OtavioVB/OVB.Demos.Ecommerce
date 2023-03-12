namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct PostalCode
{
    private string Value { get; set; }

    public PostalCode(string value)
    {
        Value = value;
    }

    public static int Length = 8;

    public override string ToString()
    {
        return Value;
    }

    public string GetValue()
    {
        return Value;
    }
}