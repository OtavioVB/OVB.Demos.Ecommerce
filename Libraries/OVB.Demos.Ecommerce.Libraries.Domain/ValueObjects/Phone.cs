namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Phone
{
    private string Value { get; set; }

    public Phone(string value)
    {
        Value = value;
    }

    public static int Length = 11;

    public override string ToString()
    {
        return Value;
    }

    public string GetValue()
    {
        return Value;
    }
}
