namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Username
{
    private string Value { get; set; }

    public Username(string value)
    {
        Value = value;
    }

    public static int MinLength = 5;
    public static int MaxLength = 24;
         
    public override string ToString()
    {
        return Value;
    }

    public string GetValue()
    {
        return Value;
    }
}
