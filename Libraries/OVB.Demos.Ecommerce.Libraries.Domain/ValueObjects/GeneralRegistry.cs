namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct GeneralRegistry
{
    private string Value { get; set; }

    public GeneralRegistry(string value)
    {
        Value = value;
    }

    public static int Length = 9;

    public override string ToString()
    {
        return Value;
    }

    public string GetValue()
    {
        return Value;
    }
}
