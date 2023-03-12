namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct SourcePlatform
{
    private string Value { get; set; }

    public SourcePlatform(string value)
    {
        Value = value;
    }

    public static int MinLength = 5;
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
