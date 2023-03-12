namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Neighborhood
{
    private string Value { get; set; }

    public Neighborhood(string value)
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
