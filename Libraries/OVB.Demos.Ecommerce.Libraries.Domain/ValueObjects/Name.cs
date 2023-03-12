namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Name
{
    private string Value { get; set; }

    public Name(string value)
    {
        Value = value;
    }

    public static int MinLength = 2;
    public static int MaxLength = 32;

    public override string ToString()
    {
        return Value;
    }

    public string GetValue()
    {
        return Value;
    }
}
