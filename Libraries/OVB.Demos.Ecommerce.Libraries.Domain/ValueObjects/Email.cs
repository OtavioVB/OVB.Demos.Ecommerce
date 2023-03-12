namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Email
{
    private string Value { get; set; }

    public Email(string value)
    {
        Value = value;
    }

    public static int MinLength = 8;
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
