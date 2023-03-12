namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct AddressComplement
{
    private string Value { get; set; }

    public AddressComplement(string value)
    {
        Value = value;
    }

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
