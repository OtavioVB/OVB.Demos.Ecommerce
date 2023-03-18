namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration;

public struct CircuitBreakerConfigurationPolicyInput
{
    public CircuitBreakerConfigurationPolicyInput(string name, int exceptionsAllowedBeforeBreak, TimeSpan durationBreak)
    {
        Name = name;
        ExceptionsAllowedBeforeBreak = exceptionsAllowedBeforeBreak;
        DurationBreak = durationBreak;
    }

    public string Name { get; init; }
    public int ExceptionsAllowedBeforeBreak { get; init; }
    public TimeSpan DurationBreak { get; init; }
}
