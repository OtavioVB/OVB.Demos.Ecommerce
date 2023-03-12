namespace OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

public struct Cpf
{
    private string Value { get; set; }

    public Cpf(string value)
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
