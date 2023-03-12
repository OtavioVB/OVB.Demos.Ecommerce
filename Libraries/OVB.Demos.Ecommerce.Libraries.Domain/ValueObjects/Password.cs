namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Password
{
    private string Value { get; set; }

    public Password(string value)
    {
        Value = value;
    }

    public static int MinLength = 8;
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
