namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Country
{
    private string Value { get; set; }

    public Country(string value)
    {
        Value = value;
    }

    public static int MinLength = 3;
    public static int MaxLength = 256;

    public override string ToString()
    {
        return Value;
    }

    public string GetValue()
    {
        return Value;
    }
}
