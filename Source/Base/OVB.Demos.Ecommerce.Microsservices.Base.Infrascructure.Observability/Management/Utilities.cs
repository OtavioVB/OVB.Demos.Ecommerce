namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;

public static class Utilities
{
    public static Dictionary<string, string> AddKeyValue(this Dictionary<string, string> dictionary, string key, string value)
    {
        dictionary.Add(key, value);
        return dictionary;
    }
}
